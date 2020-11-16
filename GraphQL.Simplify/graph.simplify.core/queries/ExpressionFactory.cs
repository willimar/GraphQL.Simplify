using graph.simplify.core.enums;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace graph.simplify.core.queries
{
    public class ExpressionFactory<TEntity> where TEntity : class
    {
        private static BinaryExpression GetStatement(Statement connector, Expression left, Expression right)
        {
            return connector switch
            {
                Statement.And => Expression.And(left, right),
                Statement.Or => Expression.Or(left, right),
                _ => Expression.And(left, right),
            };
        }

        private static BinaryExpression GetOperation(Operation operation, Expression member, Expression constant)
        {
            BinaryExpression getContains(bool contain)
            {
                var method = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });
                var arguments = new Expression[] { constant };
                var call = Expression.Call(member, method, arguments);
                return Expression.Equal(call, Expression.Constant(contain));
            }

            BinaryExpression getStartWith(bool startsWith)
            {
                var method = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });
                var arguments = new Expression[] { constant };
                var call = Expression.Call(member, method, arguments);
                return Expression.Equal(call, Expression.Constant(startsWith));
            }

            BinaryExpression getEndsWith(bool endsWith)
            {
                var method = typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) });
                var arguments = new Expression[] { constant };
                var call = Expression.Call(member, method, arguments);
                return Expression.Equal(call, Expression.Constant(endsWith));
            }

            return operation switch
            {
                Operation.EqualTo => Expression.Equal(member, constant),
                Operation.Contains => getContains(true),
                Operation.NotContains => getContains(false),
                Operation.StartsWith => getStartWith(true),
                Operation.NotStartsWith => getStartWith(false),
                Operation.EndsWith => getEndsWith(true),
                Operation.NotEndsWith => getEndsWith(false),
                Operation.NotEqualTo => Expression.NotEqual(member, constant),
                Operation.GreaterThan => Expression.GreaterThan(member, constant),
                Operation.GreaterThanOrEqualTo => Expression.GreaterThanOrEqual(member, constant),
                Operation.LessThan => Expression.LessThan(member, constant),
                Operation.LessThanOrEqualTo => Expression.LessThanOrEqual(member, constant),
                _ => Expression.Equal(member, constant),
            };
        }

        public static Expression<Func<TEntity, bool>> Factory(IResolveFieldContext<object> context)
        {
            var parameter = Expression.Parameter(typeof(TEntity), "p");
            var body = Expression.Equal(Expression.Constant(true), Expression.Constant(true));

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

                        if (order == Order.none)
                        {
                            var operation = (Operation)Convert.ChangeType(fieldValue["operation"], typeof(Operation));
                            var statement = (Statement)Convert.ChangeType(fieldValue["connector"], typeof(Statement));
                            var member = Expression.Property(parameter, fieldName);
                            object value = null;

                            if (member.Type.BaseType != null && member.Type.BaseType.Equals(typeof(Enum)))
                            {
                                value = Enum.Parse(member.Type, fieldValue["value"]?.ToString());
                            }
                            else
                            {
                                value = Convert.ChangeType(fieldValue["value"], member.Type);
                            }
                            
                            var constant = Expression.Constant(value);

                            body = GetStatement(statement, body, GetOperation(operation, member, constant));
                        }
                    }
                }
            }

            var finalExpression = Expression.Lambda<Func<TEntity, bool>>(body, parameter);
            return finalExpression;
        }
    }
}
