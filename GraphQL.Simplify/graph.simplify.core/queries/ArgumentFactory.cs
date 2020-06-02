using graph.simplify.core.enums;
using graph.simplify.core.types;
using graph.simplify.core.values;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace graph.simplify.core.queries
{
    public class ArgumentFactory
    {
        public static List<QueryArgument> Factory<TType>() where TType : class
        {
            var arquments = new List<QueryArgument>();
            var properties = typeof(TType).GetProperties();

            void addArgument<TField>(string name) where TField : class
            {
                arquments.Add(new QueryArgument<ListGraphType<ComplexInputTypes<TField>>> { Name = name });
            }

            addArgument<QueryInfoValue>("QueryInfo");

            foreach (var item in properties)
            {
                if (item.PropertyType.Equals(typeof(string)))
                {
                    addArgument<StringValue>(item.Name);
                }
                else if (item.PropertyType.Equals(typeof(int)))
                {
                    addArgument<IntValue>(item.Name);
                }
                else if (item.PropertyType.Equals(typeof(DateTime)))
                {
                    addArgument<DateTimeValue>(item.Name);
                }
                else if (item.PropertyType.BaseType.Equals(typeof(Enum)))
                {
                    addArgument<IntValue>(item.Name);
                }
                else if (item.PropertyType.Equals(typeof(decimal)))
                {
                    addArgument<DecimalValue>(item.Name);
                }
                else if (item.PropertyType.Equals(typeof(double)))
                {
                    addArgument<DoubleValue>(item.Name);
                }
                else if (item.PropertyType.Equals(typeof(float)))
                {
                    addArgument<FloatValue>(item.Name);
                }
                else if (item.PropertyType.Equals(typeof(long)))
                {
                    addArgument<LongValue>(item.Name);
                }
                else if (item.PropertyType.Equals(typeof(short)))
                {
                    addArgument<ShortValue>(item.Name);
                }
                else if (item.PropertyType.Equals(typeof(Statement)))
                {
                    addArgument<StatementValue>(item.Name);
                }
                else if (item.PropertyType.Equals(typeof(Operation)))
                {
                    addArgument<OperationValue>(item.Name);
                }
                else if (item.PropertyType.Equals(typeof(Order)))
                {
                    addArgument<OrderValue>(item.Name);
                }
                else if (item.PropertyType.Equals(typeof(bool)))
                {
                    addArgument<BoolValue>(item.Name);
                }
                else
                {
                    addArgument<StringValue>(item.Name);
                }
            }

            return arquments;
        }
    }
}
