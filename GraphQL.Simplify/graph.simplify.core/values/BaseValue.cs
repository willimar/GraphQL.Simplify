using graph.simplify.core.enums;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace graph.simplify.core.values
{
    public abstract class BaseValue<T>
    {
        public Order Order { get; set; }
        public Operation Operation { get; set; }
        public Statement Connector { get; set; }
        public T Value { get; set; }
    }
}
