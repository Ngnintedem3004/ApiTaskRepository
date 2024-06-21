using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Domain.Entities
{
    public  class MTask
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;   
        public string Description { get; set; }=string.Empty;
        public  DateTime DueDate { get; set; }
        public int Priority { get; set; }
       // public Status Status { get; set; }
        public User User { get; set; } = null!;
        public string  UserId {  get; set; }
        public string  Status {  get; set; }
    }
    public enum Status
    {
        Completed,
        Pending,
        InProgress
    }
}
