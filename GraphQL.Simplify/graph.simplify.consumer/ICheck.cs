namespace graph.simplify.consumer
{
    public interface ICheck
    {
        OperationType Operation { get; set; }
        Statement Connector { get; set; }
        object Value { get; set; }
    }
}