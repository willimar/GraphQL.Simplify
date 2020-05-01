using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace graph.simplify.core.queries
{
    internal class ExpressionFactory<TEntity> where TEntity : class
    {
        public static Expression<Func<TEntity, bool>> Factory(List<QueryArgument> arguments)
        {
            //var parameter = Expression.Parameter(typeof(Notify), "x");
            //var member = Expression.Property(parameter, "ToUser");
            //var constant = Expression.Constant(toUser);
            //var body = Expression.Equal(member, constant); //x.Id >= 3

            //ParameterExpression param = Expression.Parameter(typeof(Notify), "ToUser");
            //var finalExpression = Expression.Lambda<Func<Notify, bool>>(body, parameter); //x => x.Id >= 3

            throw new NotImplementedException();
        }
    }
}
