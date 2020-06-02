using graph.simplify.core.enums;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace graph.simplify.core.queries
{
    public class OrderFactory<TEntity> where TEntity : class
    {
        public static List<Expression<Func<TEntity, object>>> Factory(ResolveFieldContext<object> context)
        {
            var result = new List<Expression<Func<TEntity, object>>>();

            foreach (var argument in context.Arguments)
            {
                if (!argument.Key.Equals("queryInfo"))
                {
                    var fieldName = argument.Key;
                    var requirementList = argument.Value as List<object>;

                    foreach (var item in requirementList)
                    {
                        var fieldValue = item as Dictionary<string, object>;
                        var order = Order.none;

                        if (fieldValue.ContainsKey("order"))
                        {
                            order = (Order)Convert.ChangeType(fieldValue["order"], typeof(Order));
                        }

                        if (order != Order.none)
                        {
                            var parameter = Expression.Parameter(typeof(TEntity), "s");
                            var member = Expression.Property(parameter, fieldName);
                            var field = typeof(TEntity).GetProperties().FirstOrDefault(x => x.Name.ToLower().Equals(fieldName.ToLower()));
                            var call = Expression.Lambda<Func<TEntity, object>>(Expression.Convert(Expression.Property(parameter, fieldName), typeof(object)), parameter);
                            result.Add(call);
                        }
                    }
                }
            }

            return result;
        }
    }
}
