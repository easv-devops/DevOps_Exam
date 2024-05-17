using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace infrastructure.models
{
    public class TaskModel : BaseModel
    {
        public DateTime DateCreated { get; set; }
        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }
        public bool TaskStatus { get; set; }
    }
}