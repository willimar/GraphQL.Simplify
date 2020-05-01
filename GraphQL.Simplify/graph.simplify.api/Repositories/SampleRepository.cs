using crud.api.core.interfaces;
using crud.api.core.repositories;
using graph.simplify.api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace graph.simplify.api.Repositories
{
    public class SampleRepository : IRepository<Sample>
    {
        public IEnumerable<IHandleMessage> AppenData(Sample entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IHandleMessage> DeleteData(Sample entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sample> GetData(Expression<Func<Sample, bool>> func, int top = 0)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IHandleMessage> UpdateData(Sample entity, Expression<Func<Sample, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
