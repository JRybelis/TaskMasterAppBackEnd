using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskMasterApp.Data;
using TaskmasterCore.Models;

namespace TaskMasterApp.Repositories
{
    public class MockRepository
    {
        public Task<List<TaskItem>> GetAll()
        {
            return Task.FromResult(new List<TaskItem>()
            {
                new TaskItem()
                {
                    Text = "Test text",
                    Day = "Monday",
                    Reminder = false
                }
            });

        }

        public Task<TaskItem> GetById(int id)
        {
            return null;
        }

        public Task Post(TaskItem entity)
        {
            return null;
        }

        public Task Update(TaskItem entity)
        {
            return null;
        }

        public Task Delete(int id)
        {
            return Task.CompletedTask;
        }
    }
}
