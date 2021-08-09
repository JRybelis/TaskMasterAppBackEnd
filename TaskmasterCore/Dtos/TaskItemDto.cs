using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskmasterCore.Dtos
{
    public abstract class TaskItemDto
    {
        [MaxLength(511)] public string Text { get; set; }
        [MaxLength(9)]public string Day { get; set; }
        public bool Reminder { get; set; } = false;

    }
}
