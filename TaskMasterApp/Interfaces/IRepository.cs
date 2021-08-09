using System.Collections.Generic;
using System.Threading.Tasks;s
using TaskmasterCore.Models;

namespace TaskMasterApp.Interfaces
{
    public interface IRepository
    {
        Task<List<TaskItem>> GetAll();
        Task<TaskItem> GetById(int id);
        Task Upsert(TaskItem entity);
        Task Delete(int id);
    }
}
