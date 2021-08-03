using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskMasterApp.Models;

namespace TaskMasterApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Task> Get()
        {
            return new List<Task>()
            {
                new Task()
                {
                    Id = 1,
                    Text = "Buy milk",
                    Day = "Wednesday",
                    Reminder = false                    
                },
                new Task()
                {
                    Id = 2,
                    Text = "Do chores",
                    Day = "Tuesday",
                    Reminder = true                    
                }
            };
        }
    }
}
