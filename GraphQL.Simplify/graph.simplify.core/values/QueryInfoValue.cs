﻿using System;
using System.Collections.Generic;
using System.Text;

namespace graph.simplify.core.values
{
    internal class QueryInfoValue
    {
        public int Limit { get; set; }
        public int Page { get; set; }
        public string ValidateTocken { get; set; }
        public string SystemName { get; set; }
    }
}
