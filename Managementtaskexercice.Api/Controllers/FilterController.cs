using managementtaskexercice.Application.Contracts.Tasks.Filter;
using managementtaskexercice.Application.Models;
using managementtaskexercice.Task.Filter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Managementtaskexercice.Api.Controllers
{

    [Authorize(Policy = "UserOnly")]
    
    [ApiController]
    public class FilterController : ControllerBase
    {
        private readonly IAsyncFilter<UserTasks> _filterRepository;
        public FilterController(IAsyncFilter<UserTasks> filterRepository)
        {
            _filterRepository = filterRepository;
        }

        [HttpGet("/api/[controller]/DueDate")]
        public async Task <IEnumerable<UserTasks>> GetTaskByDueDate(DateTime dueDate)
        {
           
            return  await _filterRepository.FilterByDueDateAsync(dueDate);
        }
        [HttpGet("/api/[controller]/Priority")]
        public async Task<IEnumerable<UserTasks>> GetTaskByPriority(int  priority)
        {
            return await _filterRepository.FilterByPriorityAsync(priority);
        }
        [HttpGet("/api/[controller]/Status")]
        public async Task<IEnumerable<UserTasks>> GetTaskByStatus(string status)
        {
            return await _filterRepository.FilterByStatusAsync(status);
        }

    }
}
