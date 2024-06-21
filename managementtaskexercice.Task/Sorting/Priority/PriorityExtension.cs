using managementtaskexercice.Application.Models;
using managementtaskexercice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Task.Sorting.Priority
{
    public static class PriorityExtension
    {
        public static async Task<IEnumerable<UserTasks>> SortByPriority(this DbSet<MTask> tasks, Func<MTask, int> SortByPriority, Func<MTask, bool> userclaim)
        {
            var SortByPriorityQuery = tasks.Include(t => t.User)

                        .Where(userclaim)
                       .OrderBy(SortByPriority)
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

            return SortByPriorityQuery.ToList();
        }

        public static async Task<IEnumerable<UserTasks>> SortPriorityByDescending(this DbSet<MTask> tasks, Func<MTask, int> SortByPriority, Func<MTask, bool> userclaim)
        {
            var SortByPriorityOrderByDescendingQuery = tasks.Include(t => t.User).Where(userclaim)
                       .OrderByDescending(SortByPriority)
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

            return SortByPriorityOrderByDescendingQuery.ToList();
        }

    }
}

