using crud.api.core.repositories;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace graph.simplify.core.queries
{
    public class AppQuery<TEntity, TGraphType> : ObjectGraphType where TEntity : class where TGraphType : IGraphType
    {
        public AppQuery(IRepository<TEntity> repository)
        {
            var arguments = ArgumentFactory.Factory<TEntity>();

            Field<ListGraphType<TGraphType>>(typeof(TEntity).Name,
                arguments: new QueryArguments(arguments),
                resolve: context =>
                {
                    var limit = 0;
                    var page = 0;

                    if (context.Arguments.ContainsKey("queryInfo"))
                    {
                        var argument = (context.Arguments["queryInfo"] as object[])[0] as Dictionary<string, object>;
                        
                        if (argument.ContainsKey("limit"))
                        {
                            limit = Convert.ToInt32(argument["limit"]);
                        }

                        if (argument.ContainsKey("page"))
                        {
                            page = Convert.ToInt32(argument["page"]);
                        }
                    }

                    var where = ExpressionFactory<TEntity>.Factory(context);
                    var orderFields = OrderFactory<TEntity>.Factory(context);

                    return repository.GetData(where, orderFields, limit, page);
                });
        }
    }
}
