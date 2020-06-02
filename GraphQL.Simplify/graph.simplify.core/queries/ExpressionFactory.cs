using graph.simplify.core.enums;
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
            switch (connector)
            {
                case Statement.And:
                    return Expression.And(left, right);
                case Statement.Or:
                    return Expression.Or(left, right);
                default:
                    return Expression.And(left, right);
            }
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

            //BinaryExpression getEndsWith(bool endsWith)
            //{
            //    var method = typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) });
            //    var arguments = new Expression[] { constant };
            //    var call = Expression.Call(member, method, arguments);
            //    return Expression.Equal(call, Expression.Constant(endsWith));
            //}

            switch (operation)
            {
                case Operation.EqualTo:
                    return Expression.Equal(member, constant);
                case Operation.Contains:
                    return getContains(true);
                case Operation.NotContains:
                    return getContains(false);
                case Operation.StartsWith:
                    return getStartWith(true);
                case Operation.NotStartsWith:
                    return getStartWith(false);
                case Operation.EndsWith:
                    return getEndsWith(true);
                case Operation.NotEndsWith:
                    return getEndsWith(false);
                //case Operation.IsNullOrWhiteSpace:
                //    return getIsNullOrWhiteSpace(true);
                case Operation.NotEqualTo:
                    return Expression.NotEqual(member, constant);
                case Operation.GreaterThan:
                    return Expression.GreaterThan(member, constant);
                case Operation.GreaterThanOrEqualTo:
                    return Expression.GreaterThanOrEqual(member, constant);
                case Operation.LessThan:
                    return Expression.LessThan(member, constant);
                case Operation.LessThanOrEqualTo:
                    return Expression.LessThanOrEqual(member, constant);
                default:
                    return Expression.Equal(member, constant);
            }
        }

        public static Expression<Func<TEntity, bool>> Factory(ResolveFieldContext<object> context)
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
                            var value = Convert.ChangeType(fieldValue["value"], fieldValue["value"]?.GetType());

                            var member = Expression.Property(parameter, fieldName);
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
