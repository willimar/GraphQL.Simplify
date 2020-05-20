﻿using System;
using System.Collections.Generic;
using System.Text;

namespace graph.simplify.consumer
{
    public interface IBody 
    {
        string Name { get; }
        IQueryInfo QueryInfo { get; }
        List<IArgument> Arguments { get; }
        List<string> ResultFields { get; }
        IArgument AppendArgument(string name);
        List<Type> StringFormat { get; }
    }
}