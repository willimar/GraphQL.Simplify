using crud.api.core.repositories;
using GraphQL.Types;
using System;
using System.Collections.Generic;
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
                    return repository.GetData(ExpressionFactory<TEntity>.Factory(context));
                });
        }
    }
}
