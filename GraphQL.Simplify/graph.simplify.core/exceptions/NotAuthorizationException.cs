using System;
using System.Collections.Generic;
using System.Text;

namespace graph.simplify.core.exceptions
{
    public class NotAuthorizationException: Exception
    {
        public NotAuthorizationException() : base("You haven't access in this service.")
        {

        }
    }
}
