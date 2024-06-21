using managementtaskexercice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using managementtaskexercice.Application.Contracts.Users.Authenticate;
using managementtaskexercice.Application.Contracts.Persistence;
using managementtaskexercice.Application.Models;
using managementtaskexercice.Application.Contracts.Specifications;
namespace managementtaskexercice.Persistence.Repositories
{
    public class MtaskRepository : BaseRepository, IAsyncTaskRepository
    {
        private  IVerifyUserIdClaim _VerifyUserIdClaim;
        private IUpdateTaskSpecification _UpdateTaskSpecification;
        public MtaskRepository(ManagementtaskDbContext context, IVerifyUserIdClaim verifyUserIdClaim,IUpdateTaskSpecification updateTaskSpecification) : base(context)
        {
            _VerifyUserIdClaim = verifyUserIdClaim;
            _UpdateTaskSpecification = updateTaskSpecification;
        }
        public  async  Task AddAsync(MTaskDto task)
        {
           var Mtask = new MTask
            {
                UserId=_VerifyUserIdClaim.HasUserIdClaim().Value,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Priority = task.Priority,
                Status = task.Status
            };
           await _context.Tasks.AddAsync(Mtask);

           await  _context.SaveChangesAsync();
        }
        public  async Task<IEnumerable<UserTasks>> GetAllAsync()
        {

            return _context.Tasks.Where(t => t.UserId == _VerifyUserIdClaim.HasUserIdClaim().Value)
                .Select(t => new UserTasks
                {
                    UserEmail = t.User.Email,
                    UserId = t.UserId,
                    DueDate = t.DueDate,
                    Priority = t.Priority,

                    Description = t.Description,
                    Title = t.Title,
                    Status = t.Status,
                    IdTask=t.Id
                }).ToList();
        }

        public async Task<UserTasks> GetByIdAsync(int id)
        {
            UserTasks userTasks=new UserTasks();
            
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                if (task.UserId == _VerifyUserIdClaim.HasUserIdClaim().Value)
                {
                    userTasks = new UserTasks
                    {
                        UserId = task.UserId,
                        DueDate = task.DueDate,
                        Priority = task.Priority,
                        Description = task.Description,
                        Title = task.Title,
                        Status = task.Status,
                        IdTask = task.Id
                    };
                    return userTasks;
                }
            }

            return userTasks;
        }
        public async Task UpdateAsync(int id ,MTaskDto task)
        {
            var mtask = await _context.Tasks.FindAsync(id);
            if (mtask != null)
            {
                if (mtask.UserId == _VerifyUserIdClaim.HasUserIdClaim().Value)
                {
                    if (task.Status == "Completed")
                    {
                        if (_UpdateTaskSpecification.HasDueDateExpired(task))
                        {
                            mtask.Status = "Pending";
                        }
                        else 
                        {
                            mtask.Status = "Completed";
                        }
                    }
    
                    mtask.Status= task.Status;

                    _context.Entry(mtask).State = EntityState.Modified;
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                if (task.UserId == _VerifyUserIdClaim.HasUserIdClaim().Value)
                {
                    _context.Tasks.Remove(task);
                }
            }
            await _context.SaveChangesAsync();
        }


    }
}
