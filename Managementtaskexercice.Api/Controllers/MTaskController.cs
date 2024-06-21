using FluentValidation;
using managementtaskexercice.Application.Contracts.Persistence;
using managementtaskexercice.Application.Contracts.Specifications;
using managementtaskexercice.Application.Models;
using managementtaskexercice.Application.Validators;
using managementtaskexercice.Authentication.Extensions.Session;
using managementtaskexercice.Domain.Entities;
using managementtaskexercice.Persistence.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Managementtaskexercice.Api.Controllers
{

    [Authorize(Policy = "UserOnly")]
    [ApiController]
    public class MTaskController : ControllerBase
    {
        private MTaskValidator mTaskValidator;
        private IAsyncTaskRepository _mtaskrepository;
        private ILogger<MTaskController> _logger;
        private IUpdateTaskSpecification _updateTaskSpecification;
        public MTaskController(IAsyncTaskRepository mtaskRepository, ILogger<MTaskController> logger,IUpdateTaskSpecification updateTaskSpecification)
        {
            _mtaskrepository = mtaskRepository;
            mTaskValidator = new MTaskValidator();
            _logger = logger;
            _updateTaskSpecification = updateTaskSpecification;
        }

        [HttpGet("/api/Tasks")]
        public async Task<IEnumerable<UserTasks>> GetAllTask()    
        {
            return await _mtaskrepository.GetAllAsync();
        }
        [HttpGet("/api/Tasks/{id}")]
        public async Task<ActionResult<UserTasks>> GetTaskById(int id)
        {
            return await _mtaskrepository.GetByIdAsync(id);
        }
        
        [HttpPost("/api/Tasks/Create")]
        public async Task<ActionResult<UserTasks>> AddTask(MTaskDto mTaskDto)
        {
            var result = mTaskValidator.Validate(mTaskDto);
            if(result.Errors.Count > 0)
            {
                return BadRequest(result.Errors);
            }
            await _mtaskrepository.AddAsync(mTaskDto);
            _logger.LogInformation(5,"task created with the title {title} at { date}",mTaskDto.Title,DateTime.Now);
            return CreatedAtAction(nameof(AddTask), new { title = mTaskDto.Title });
        }
        
        [HttpPut("/api/Tasks/Update/{id}")]
        public async Task<ActionResult> PutTask(int id, MTaskDto task)
        {
            var result = mTaskValidator.Validate(task);
            if (result.Errors.Count > 0)
            {
                return BadRequest(result.Errors);



            }
            _logger.LogInformation(4,"task update with the title {title} at { date}", task.Title, DateTime.Now);
            await _mtaskrepository.UpdateAsync(id,task);
            return NoContent();
        }
        /// <summary>
        /// Deletes a specific Task.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("/api/Tasks/Delete/{id}")]
        public async  Task<IActionResult> DeleteTask(int id)
        {
            await _mtaskrepository?.DeleteAsync(id);
            _logger.LogInformation(3,"task delete   at { date}",  DateTime.Now);

            return NoContent();
        }

    }
    
}
