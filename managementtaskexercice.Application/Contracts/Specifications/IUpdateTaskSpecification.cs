using managementtaskexercice.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Application.Contracts.Specifications
{
    public  interface IUpdateTaskSpecification
    {
        public bool HasDueDateExpired(MTaskDto task);
    }
}
