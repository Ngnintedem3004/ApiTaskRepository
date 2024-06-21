using managementtaskexercice.Application.Contracts.Tasks.Pagination;
using managementtaskexercice.Application.Contracts.Users.Authenticate;
using managementtaskexercice.Application.Models;
using managementtaskexercice.Domain.Entities;
using managementtaskexercice.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Task.Pagination
{
    public  class PagingRepository:BaseRepository,IPagination
    {
        private IVerifyUserIdClaim _verifyUserIdClaim;
        
        public PagingRepository(ManagementtaskDbContext context,IVerifyUserIdClaim verifyUserIdClaim)
            :base(context)
        { 
            _verifyUserIdClaim = verifyUserIdClaim;
        }

        public async  Task<IEnumerable<UserTasks>> GetUserTaskBySize(ParametersOfPaging userParametersOfPaging)
        {


            var tasks =   _context.Tasks
                .Include(t=>t.User)
               .Where(t=>t.UserId==_verifyUserIdClaim.HasUserIdClaim().Value)
                .Skip((userParametersOfPaging.PageNumber-1)*userParametersOfPaging.NumberOfTasks)
                .Take(userParametersOfPaging.NumberOfTasks)
                .Select(t => new UserTasks
                {
                    IdTask = t.Id,
                    UserEmail = t.User.Email,
                    UserId = t.UserId,
                    DueDate = t.DueDate,
                    Priority = t.Priority,
                    Description = t.Description,
                    Title = t.Title,
                    Status = t.Status

                });


            return tasks.ToList();       
        }
    }
}
