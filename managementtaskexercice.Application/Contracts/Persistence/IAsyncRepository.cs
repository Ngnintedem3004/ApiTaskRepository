using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T>
    {
        public Task<T> GetByIdAsync(int id);
        public Task AddAsync(T entity);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(int id);
    }
    

}
