using managementtaskexercice.Application.Contracts.Specifications;
using managementtaskexercice.Application.Models;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Application.Specifications.MTask
{
    public  class UpdateTaskSpecification: IUpdateTaskSpecification
    {
        public  bool HasDueDateExpired(MTaskDto task)
        {

            return (DateTime.Today > task.DueDate) ? true : false;
        }
    }
}
