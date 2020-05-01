using crud.api.core.repositories;
using graph.simplify.api.Entities;
using graph.simplify.api.Repositories;
using graph.simplify.api.Types;
using graph.simplify.core.queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graph.simplify.api.Queries
{
    public class SampleQuery : AppQuery<Sample, SampleType>
    {
        public SampleQuery(SampleRepository repository) : base(repository)
        {
        }        
    }
}
