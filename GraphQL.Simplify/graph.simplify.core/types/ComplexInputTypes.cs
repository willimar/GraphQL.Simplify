using graph.simplify.core.enums;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace graph.simplify.core.types
{
    public class ComplexInputTypes<TType> : InputObjectGraphType where TType : class
    {
        public ComplexInputTypes()
        {
            Name = typeof(TType).Name;

            var properties = typeof(TType).GetProperties();

            properties.ToList().ForEach(item => {
                if (item.PropertyType.Equals(typeof(string)))
                {
                    Field<StringGraphType>(item.Name);
                }
                else if (item.PropertyType.Equals(typeof(int)))
                {
                    Field<IntGraphType>(item.Name);
                }
                else if (item.PropertyType.Equals(typeof(DateTime)))
                {
                    Field<DateTimeGraphType>(item.Name);
                }
                else if (item.PropertyType.Equals(typeof(Operation)))
                {
                    Field<EnumeratorType<Operation>>(item.Name);
                }
                else if (item.PropertyType.Equals(typeof(Statement)))
                {
                    Field<EnumeratorType<Statement>>(item.Name);
                }
                else if (item.PropertyType.BaseType.Equals(typeof(Enum)))
                {
                    Field<IntGraphType>(item.Name);
                }
                else if (item.PropertyType.Equals(typeof(bool)))
                {
                    Field<BooleanGraphType>(item.Name);
                }
                else if (item.PropertyType.Equals(typeof(decimal)))
                {
                    Field<DecimalGraphType>(item.Name);
                }
                else if (item.PropertyType.Equals(typeof(double)))
                {
                    Field<DecimalGraphType>(item.Name);
                }
                else if (item.PropertyType.Equals(typeof(float)))
                {
                    Field<FloatGraphType>(item.Name);
                }
                else if (item.PropertyType.Equals(typeof(long)))
                {
                    Field<ULongGraphType>(item.Name);
                }
                else if (item.PropertyType.Equals(typeof(short)))
                {
                    Field<ShortGraphType>(item.Name);
                }
                else 
                {
                    Field<StringGraphType>(item.Name);
                }
            });
        }
    }
}
