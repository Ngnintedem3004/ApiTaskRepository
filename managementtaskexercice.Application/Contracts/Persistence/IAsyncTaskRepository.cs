using managementtaskexercice.Application.Models;
using managementtaskexercice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Application.Contracts.Persistence
{
    public  interface IAsyncTaskRepository 
    {
        public Task<UserTasks> GetByIdAsync(int id);
        public Task AddAsync(MTaskDto task);
        public Task<IEnumerable<UserTasks>> GetAllAsync();
        public Task UpdateAsync(int id,MTaskDto task);
        public Task DeleteAsync(int id);
    }
}
