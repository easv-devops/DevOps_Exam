using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace api.TransferModels.TaskModelDto
{
    public class CreateTaskDto
    {
        [Required, NotNull]
        [MinLength(3), MaxLength(50)]
        public string? TaskName { get; set; }
        [Required, NotNull]
        [MinLength(3), MaxLength(50)]
        public string? TaskDescription { get; set; }
        [Required, NotNull]
        public bool TaskStatus {get; set;} = false;
    }
}