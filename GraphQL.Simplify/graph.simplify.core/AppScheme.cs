using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace graph.simplify.core
{
    public class AppScheme<TQuery> : Schema where TQuery : IObjectGraphType
    {
        public AppScheme(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<TQuery>();
        }
    }
}
