using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace graph.simplify.core.types
{
    public class EnumeratorType<TEnum>: EnumerationGraphType where TEnum : Enum
    {
        public EnumeratorType()
        {
            var fields = typeof(TEnum).GetEnumValues();

            Name = typeof(TEnum).Name;

            foreach (var field in fields)
            {
                AddValue(field.ToString(), $"Valule to field {field.ToString()} is {(int)field}", field);
            }
        }
    }
}
