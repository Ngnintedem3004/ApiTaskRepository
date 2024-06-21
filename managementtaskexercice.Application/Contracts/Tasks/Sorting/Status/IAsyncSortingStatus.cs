using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Application.Contracts.Tasks.Sorting.Status
{
    public interface  IAsyncSortingStatus<T> where T : class
    {
        public Task<IEnumerable<T>> SortByStatusAsync();
        public Task<IEnumerable<T>> SortByStatusOrderByDscendingAsync();
    }
}
