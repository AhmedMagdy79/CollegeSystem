using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSystem.Core.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);

        Task<IEnumerable<T>> GetAllAsync();
        
        Task<T> GetByIdAsync(int id);

        Task<T> GetByIdAsync(string id);

        T Delete(T entity);

        T Update (T entity);
    }
}
