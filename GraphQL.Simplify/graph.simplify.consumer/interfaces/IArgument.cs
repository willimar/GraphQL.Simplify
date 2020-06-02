using graph.simplify.consumer.enums;
using System.Collections.Generic;

namespace graph.simplify.consumer.interfaces
{
    public interface IArgument
    {
        string Name { get; }
        List<ICheck> Checks { get; }
        IArgument AppendCheck(OperationType operation, Statement connector, object value);
        IArgument AppendCheck(Order order);
    }
}