using graph.simplify.api.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graph.simplify.api.Types
{
    public class SampleType : ObjectGraphType<Sample>
    {
        public SampleType()
        {
            //Field(x => x.Id, type: typeof(IdGraphType))
            //    .Description("Property Id is Gui type and unique in database.");
            var message = "Materialize a '{0}' type variable.";

            Field(x => x.BooleanProperty).Description(string.Format(message, "boolean"));
            //Field(x => x.ByteProperty).Description(string.Format(message, "byte"));
            //Field(x => x.CharProperty).Description(string.Format(message, "char"));
            Field(x => x.DateTimeProperty).Description(string.Format(message, "date and time"));
            Field(x => x.DecimalProperty).Description(string.Format(message, "decimal"));
            Field(x => x.DoubleProperty).Description(string.Format(message, "double"));
            Field(x => x.FloatProperty).Description(string.Format(message, "float"));
            Field(x => x.IntProperty).Description(string.Format(message, "int"));
            Field(x => x.LongProperty).Description(string.Format(message, "long"));
            //Field(x => x.ShortProperty).Description(string.Format(message, "short"));
            Field(x => x.StringProperty).Description(string.Format(message, "string"));
            Field<IntGraphType>("EnumeratorProperty", resolve: context => (int)context.Source.EnumeratorProperty, description: string.Format(message, "enumerator"));

        }
    }
}
