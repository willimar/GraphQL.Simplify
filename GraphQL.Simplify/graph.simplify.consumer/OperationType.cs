namespace graph.simplify.consumer
{
    public enum OperationType
    {
        EqualTo = 1,
        Contains = 2,
        StartsWith = 3,
        EndsWith = 4,
        NotEqualTo = 5,
        GreaterThan = 6,
        GreaterThanOrEqualTo = 7,
        LessThan = 8,
        LessThanOrEqualTo = 9,
        NotContains = 10,
        NotStartsWith = 11,
        NotEndsWith = 12,
        //Between = 10,
        //IsNull = 11,
        //IsEmpty = 12,
        IsNullOrWhiteSpace = 13,
        //IsNotNull = 14,
        //IsNotEmpty = 15,
        //IsNotNullNorWhiteSpace = 16,
        //In = 17
    }
}