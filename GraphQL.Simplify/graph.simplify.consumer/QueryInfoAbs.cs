using System;
using System.Collections.Generic;
using System.Text;

namespace graph.simplify.consumer
{
    internal class QueryInfoAbs : IQueryInfo
    {
        public int Limit { get; set; }
        public int Page { get; set; }
    }
}
