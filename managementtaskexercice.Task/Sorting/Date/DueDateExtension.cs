using managementtaskexercice.Application.Models;
using managementtaskexercice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Task.Sorting.Date
{
    public static class DueDateExtension
    {
        public static async Task<IEnumerable<UserTasks>> SortDueDate(this DbSet<MTask> tasks, Func<MTask, DateTime> SortDatime, Func<MTask, bool> userclaim)
        {
            var OrderByAscQuery = tasks.Include(t => t.User)
                       .Where(userclaim)
                       .OrderBy(SortDatime)
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

            return OrderByAscQuery.ToList();


        }

        public static async Task<IEnumerable<UserTasks>> SortDueDateByDescending(this DbSet<MTask> tasks,Func<MTask,DateTime> sortdatime, Func<MTask,bool> userclaim)
        {
            var OrderByDescQuery = tasks.Include(t => t.User)
                       .OrderByDescending(sortdatime)
                        .Where(userclaim)
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

            return OrderByDescQuery.ToList();
        }

    }
}
