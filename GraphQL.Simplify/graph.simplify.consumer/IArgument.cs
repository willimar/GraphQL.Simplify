using System.Collections.Generic;

namespace graph.simplify.consumer
{
    public interface IArgument
    {
        string Name { get; }
        List<ICheck> Checks { get; }
        IArgument AppendCheck(OperationType operation, Statement connector, object value);
    }
}