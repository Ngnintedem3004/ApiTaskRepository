using managementtaskexercice.Application.Contracts.Tasks.Pagination;
using managementtaskexercice.Application.Models;
using managementtaskexercice.Application.Validators;
using managementtaskexercice.Domain.Entities;
using managementtaskexercice.Task.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Managementtaskexercice.Api.Controllers
{

    [Authorize(Policy ="UserOnly")]
    [Route("api/[controller]")]
    [ApiController]
    public class PaginationController : ControllerBase
    {
        private readonly IPagination _pagingRepository;
        private ParameterPagingValidator _parameterpagingvalidator;
        public PaginationController (IPagination pagingRepository) { 

            _pagingRepository = pagingRepository;
            _parameterpagingvalidator =new ParameterPagingValidator();
        }
        [HttpGet("/api/[controller]")]
        public async Task<IEnumerable<UserTasks>> GetUserTaskBySize(ParametersOfPaging ParametersOfPaging)
        {
            var result = _parameterpagingvalidator.Validate(ParametersOfPaging);
            if (result.Errors.Count > 0)
            {
                return (IEnumerable<UserTasks>)result.Errors;
            }
                
            

            return await _pagingRepository.GetUserTaskBySize(ParametersOfPaging);
        }
    }
}
