using managementtaskexercice.Application.Models;
using managementtaskexercice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Application.Contracts.Tasks.Pagination
{
    public interface IPagination
    {
        public Task<IEnumerable<UserTasks>> GetUserTaskBySize(ParametersOfPaging parameter);
    }
}
