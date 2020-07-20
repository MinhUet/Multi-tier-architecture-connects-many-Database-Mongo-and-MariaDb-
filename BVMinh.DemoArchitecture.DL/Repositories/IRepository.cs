using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVMinh.DemoArchitecture.DL.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<string> Insert(T entity);
        Task Update(T entity);
        Task<IQueryable<T>> GetAll();
        Task<T> GetById(string id);
        Task<long> Delete(string id);
    }
}
