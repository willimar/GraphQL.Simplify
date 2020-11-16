using System;
using System.Collections.Generic;
using System.Text;

namespace graph.simplify.core.exceptions
{
    public class SystemNameNotFoundException: Exception
    {
        public SystemNameNotFoundException(): base("Please, check your systema name in QueryInfoValue.")
        {

        }
    }
}
