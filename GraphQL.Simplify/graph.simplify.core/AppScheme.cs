using GraphQL;
using GraphQL.Types;
using GraphQL.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace graph.simplify.core
{
    public class AppScheme<TQuery> : Schema where TQuery : IObjectGraphType
    {
        public AppScheme(IServiceProvider provider) : base()
        {
            Query = provider.GetRequiredService<TQuery>();
        }
    }
}
