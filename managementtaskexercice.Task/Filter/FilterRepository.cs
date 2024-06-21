using managementtaskexercice.Application.Contracts.Tasks.Filter;
using managementtaskexercice.Application.Contracts.Users.Authenticate;
using managementtaskexercice.Application.Models;
//using managementtaskexercice.Domain.Entities;
using managementtaskexercice.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace managementtaskexercice.Task.Filter
{
    
    public class FilterRepository : BaseRepository,IAsyncFilter<UserTasks>
    {
        private IVerifyUserIdClaim _verifyUserIdClaim;


        public FilterRepository(ManagementtaskDbContext context,IVerifyUserIdClaim verifyUserIdClaim)
            :base(context) {
            _verifyUserIdClaim = verifyUserIdClaim;
        }
       
        public async Task<IEnumerable<UserTasks>> FilterByDueDateAsync(DateTime Date)
        {

            var query = _context.Tasks.Filter(task => task.DueDate == Date &&  task.UserId==_verifyUserIdClaim.HasUserIdClaim().Value );

            return await query;

        }
        public async Task<IEnumerable<UserTasks>> FilterByPriorityAsync(int Priority)
        {
            
            
           var query= _context.Tasks.Filter(task => task.Priority == Priority && task.UserId == _verifyUserIdClaim.HasUserIdClaim().Value);

            return await query;

        }

        public  async Task<IEnumerable<UserTasks>> FilterByStatusAsync(string Status)
        {
            var query = _context.Tasks.Filter(task => task.Status == Status && task.UserId == _verifyUserIdClaim.HasUserIdClaim().Value);

            return await query;

        }
    }
}
