using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Application.Contracts.Tasks.Sorting.DueDate
{
    public interface   IAsyncSortingDueDate<T> where T : class
    {
        public Task<IEnumerable<T>> SortByDueDateAsync();
        public Task<IEnumerable<T>> SortByDueDateOrderByDescendingAsync();
    }
}
