namespace graph.simplify.consumer
{
    public interface IQueryInfo
    {
        int Limit { get; set; }
        int Page { get; set; }
    }
}