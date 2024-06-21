using managementtaskexercice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Application.Models
{
    public  class UserTasks
    {

        public string UserId { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public int IdTask {  get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public int Priority { get; set; }
        public string Status { get; set; } = string.Empty;


    }
}

