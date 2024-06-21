using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Application.Contracts.Tasks.Sorting.Priority
{
    public  interface  IAsyncSortingPriority<T> where T : class
    {
        public Task<IEnumerable<T>> SortByPriorityAsync();
        public Task<IEnumerable<T>> SortByPriorityOrderByDescendingAsync();
    }
}
