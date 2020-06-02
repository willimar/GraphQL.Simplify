using graph.simplify.consumer.enums;

namespace graph.simplify.consumer.interfaces
{
    public interface ICheck
    {
        OperationType Operation { get; set; }
        Statement Connector { get; set; }
        Order Order { get; set; }
        object Value { get; set; }
    }
}