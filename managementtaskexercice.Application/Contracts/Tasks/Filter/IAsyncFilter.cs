using managementtaskexercice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Application.Contracts.Tasks.Filter
{
    public interface IAsyncFilter< T> where T : class
    {
        public Task<IEnumerable<T>> FilterByPriorityAsync(int priority);
        public Task<IEnumerable<T>> FilterByStatusAsync(string Status);
        public Task<IEnumerable<T>> FilterByDueDateAsync(DateTime Date);
    }
}
