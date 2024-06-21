using managementtaskexercice.Application.Models;
using managementtaskexercice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Task.Filter
{
    public static class FilterExtension
    {
        public static async  Task<IEnumerable<UserTasks>> Filter (this DbSet<MTask> tasks,Func<MTask,bool> filter)
        {
           
          
            var query =  tasks.Include(t => t.User)
                       .Where(filter)
                        .Select(t=> new UserTasks
                        {
                            IdTask=t.Id,
                            UserEmail =t.User.Email,
                            UserId = t.UserId,
                            DueDate = t.DueDate,
                            Priority = t.Priority,
                            Description = t.Description,
                            Title = t.Title,
                            Status = t.Status

                        });

            return  query.ToList();

        }
    }
}
