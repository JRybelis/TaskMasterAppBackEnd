using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMasterApp.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Day { get; set; }
        public bool Reminder { get; set; } = false;
    }
}
