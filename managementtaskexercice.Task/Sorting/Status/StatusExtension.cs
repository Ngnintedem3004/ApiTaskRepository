using managementtaskexercice.Application.Models;
using managementtaskexercice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Task.Sorting.Status
{
    public static  class StatusExtension
    {
        public static object SortByPriorityQuery { get; private set; }

        public static async Task<IEnumerable<UserTasks>> SortStatus(this DbSet<MTask> tasks, Func<MTask, string> SortStatus)
        {
            var SortByStatusQuery = tasks.Include(t => t.User)
                       .OrderBy(SortStatus)
                        .Select(t => new UserTasks
                        {
                            UserEmail = t.User.Email,
                            UserId = t.UserId,
                            DueDate = t.DueDate,
                            Priority = t.Priority,
                            Description = t.Description,
                            Title = t.Title,
                            Status = t.Status

                        });

            return SortByStatusQuery.ToList();

        }

        public static async Task<IEnumerable<UserTasks>> SortStatusByDescending(this DbSet<MTask> tasks, Func<MTask, string> SortStatus, Func<MTask, bool> userclaim)
        {
            var SortByPriorityOrderByDescendingQuery = tasks.Include(t => t.User).Where(userclaim)
                       .OrderByDescending(SortStatus)
                        .Select(t => new UserTasks
                        {
                            IdTask=t.Id,
                            UserEmail = t.User.Email,
                            UserId = t.UserId,
                            DueDate = t.DueDate,
                            Priority = t.Priority,
                            Description = t.Description,
                            Title = t.Title,
                            Status = t.Status

                        });

            return SortByPriorityOrderByDescendingQuery.ToList();
        }
    }
}
