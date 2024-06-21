using managementtaskexercice.Application.Contracts.Tasks.Sorting;
using managementtaskexercice.Application.Contracts.Tasks.Sorting.DueDate;
using managementtaskexercice.Application.Contracts.Tasks.Sorting.Priority;
using managementtaskexercice.Application.Contracts.Tasks.Sorting.Status;
using managementtaskexercice.Application.Contracts.Users.Authenticate;
using managementtaskexercice.Application.Models;
using managementtaskexercice.Domain.Entities;
using managementtaskexercice.Persistence;
using managementtaskexercice.Task.Sorting.Date;
using managementtaskexercice.Task.Sorting.Priority;
using managementtaskexercice.Task.Sorting.Status;
using Microsoft.EntityFrameworkCore;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace managementtaskexercice.Task.Sorting
{
    public class SortingRepository : BaseRepository,IAsyncSortingDueDate<UserTasks>,IAsyncSortingPriority<UserTasks>,IAsyncSortingStatus<UserTasks>
    {
        private IVerifyUserIdClaim _verifyUserIdClaim;

        public SortingRepository(ManagementtaskDbContext context,IVerifyUserIdClaim verifyUserIdClaim)
            :base(context)
        { 
            _verifyUserIdClaim = verifyUserIdClaim;
        }
        public async Task<IEnumerable<UserTasks>> SortByDueDateAsync()
        {

            var tasks = _context.Tasks.SortDueDate(t => t.DueDate,t=>t.UserId==_verifyUserIdClaim.HasUserIdClaim().Value);

            return await tasks;

        }

        public async Task<IEnumerable<UserTasks>> SortByDueDateOrderByDescendingAsync()
        {
            var tasks=_context.Tasks.SortDueDateByDescending( t=>t.DueDate,t => t.UserId == _verifyUserIdClaim.HasUserIdClaim().Value);
            return await tasks;
        }

        public async  Task<IEnumerable<UserTasks>> SortByPriorityAsync()
        {
    
            var tasks = _context.Tasks.SortByPriority(t => t.Priority, t => t.UserId == _verifyUserIdClaim.HasUserIdClaim().Value);

            return await tasks;
        }

        public async Task<IEnumerable<UserTasks>> SortByPriorityOrderByDescendingAsync()
        {
            var tasks=_context.Tasks.SortPriorityByDescending(t=> t.Priority, t => t.UserId == _verifyUserIdClaim.HasUserIdClaim().Value);
            return await tasks;
        }

        public async  Task<IEnumerable<UserTasks>> SortByStatusAsync()
        {

            var tasks = _context.Tasks.SortStatus(t => t.Status);

            return await tasks;
        }


        public async Task<IEnumerable<UserTasks>> SortByStatusOrderByDscendingAsync()
        {
            var tasks=_context.Tasks.SortStatusByDescending(t => t.Status, t => t.UserId == _verifyUserIdClaim.HasUserIdClaim().Value);
            return await tasks;
        }
    }
}
