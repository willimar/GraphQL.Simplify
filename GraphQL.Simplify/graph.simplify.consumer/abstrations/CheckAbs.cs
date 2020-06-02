using graph.simplify.consumer.enums;
using graph.simplify.consumer.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace graph.simplify.consumer.abstractions
{
    internal class CheckAbs : ICheck
    {
        public OperationType Operation { get; set; }
        public Statement Connector { get; set; }
        public Order Order { get; set; }
        public object Value { get; set; }
    }
}
