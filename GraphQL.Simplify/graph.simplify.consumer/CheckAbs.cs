using System;
using System.Collections.Generic;
using System.Text;

namespace graph.simplify.consumer
{
    internal class CheckAbs : ICheck
    {
        public OperationType Operation { get; set; }
        public Statement Connector { get; set; }
        public object Value { get; set; }
    }
}
