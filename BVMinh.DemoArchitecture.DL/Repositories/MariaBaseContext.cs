using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVMinh.DemoArchitecture.DL.Repositories
{
    public class MariaBaseContext<T> : IRepository<T> where T : class
    {
        public Task<long> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<string> Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
