using crud.api.core.repositories;
using graph.simplify.core.exceptions;
using GraphQL.Types;
using Jwt.Simplify.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace graph.simplify.core.queries
{
    public class AppQuery<TEntity, TGraphType> : ObjectGraphType where TEntity : class where TGraphType : IGraphType
    {
        public bool UseAuthenticate { get; set; }
        public Uri AuthenticateApi { get; set; }

        public AppQuery(IRepository<TEntity> repository)
        {
            var arguments = ArgumentFactory.Factory<TEntity>();
            var entityName = typeof(TEntity).Name.Replace("`1", string.Empty);


            Field<ListGraphType<TGraphType>>(entityName,
                arguments: new QueryArguments(arguments),
                resolve: context =>
                {
                    var limit = 0;
                    var page = 0;

                    if (context.Arguments.ContainsKey("queryInfo"))
                    {
                        var argument = (context.Arguments["queryInfo"] as object[])[0] as Dictionary<string, object>;

                        if (this.UseAuthenticate && !argument.ContainsKey("validateTocken"))
                        {
                            throw new NotAuthorizationException();
                        }

                        if (this.UseAuthenticate && !argument.ContainsKey("systemName"))
                        {
                            throw new SystemNameNotFoundException();
                        }

                        if (this.UseAuthenticate)
                        {
                            var token = Convert.ToString(argument["validateTocken"]);
                            var systemName = Convert.ToString(argument["systemName"]);
                            var uri = new Uri(this.AuthenticateApi, "api/Authorized");

                            var auth = token.CheckToken(uri.ToString());

                            var hasAccress = auth.HasAccess(RulerType.ViewUser, entityName);
                            
                            if (!hasAccress)
                            {
                                throw new NotAuthorizationException();
                            }

                            var accountId = auth.GetAccountId(systemName);

                            if (accountId.Equals(Guid.Empty))
                            {
                                throw new NotAuthorizationException();
                            }
                        }
                        
                        if (argument.ContainsKey("limit"))
                        {
                            limit = Convert.ToInt32(argument["limit"]);
                        }

                        if (argument.ContainsKey("page"))
                        {
                            page = Convert.ToInt32(argument["page"]);
                        }

                    }
                    else if (this.UseAuthenticate && !context.Arguments.ContainsKey("queryInfo"))
                    {
                        throw new NotAuthorizationException();
                    }

                    var where = ExpressionFactory<TEntity>.Factory(context);
                    var orderFields = OrderFactory<TEntity>.Factory(context);

                    return repository.GetData(where, orderFields, limit, page);
                });
        }
    }
}
