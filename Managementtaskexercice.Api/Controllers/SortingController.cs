using managementtaskexercice.Application.Models;
using managementtaskexercice.Domain.Entities;
using managementtaskexercice.Task.Sorting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Managementtaskexercice.Api.Controllers
{
    [Authorize(Policy = "UserOnly")]

    [Route("api/[controller]")]
    [ApiController]
    public class SortingController : ControllerBase
    {
        private readonly SortingRepository _sortingRepository;
        public SortingController(SortingRepository sortingRepository)
        {
            _sortingRepository = sortingRepository;
        }

        [HttpGet("/api/[controller]/DueDate")]
        public async Task <IEnumerable<UserTasks>> SortingTaskByDueDate()
        {

            return  await _sortingRepository.SortByDueDateAsync();
        }
        [HttpGet("/api/[controller]/DueDate/Desc")]
        public async Task<IEnumerable<UserTasks>> SortingTaskByDueDateOrderByDescending()
        {

            return await _sortingRepository.SortByDueDateOrderByDescendingAsync();
        }
        [HttpGet("/api/[controller]/Priority")]
        public async Task<IEnumerable<UserTasks>> SortingTaskByPriority()
        {

            return await _sortingRepository.SortByPriorityAsync();
        }
        [HttpGet("/api/[controller]/Priority/Desc")]
        public async Task<IEnumerable<UserTasks>> SortingTaskByPriorityOderByDescending()
        {

            return await _sortingRepository.SortByPriorityOrderByDescendingAsync();
        }
        [HttpGet("/api/[controller]/Status")]
        public async Task<IEnumerable<UserTasks>> SortingTaskByStatus()
        {

            return await _sortingRepository.SortByStatusAsync();
        }
        [HttpGet("/api/[controller]/Status/Desc")]
        public async Task<IEnumerable<UserTasks>> SortingTaskByStatusOrderByDescending()
        {

            return await _sortingRepository.SortByStatusOrderByDscendingAsync();
        }

    }
}
