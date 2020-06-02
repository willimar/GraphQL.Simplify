using graph.simplify.consumer.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace graph.simplify.consumer.abstractions
{
    internal class QueryInfoAbs : IQueryInfo
    {
        public int Limit { get; set; }
        public int Page { get; set; }
    }
}
