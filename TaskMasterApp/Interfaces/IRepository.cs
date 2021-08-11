using System.Collections.Generic;
using System.Threading.Tasks;
using TaskmasterCore.Models;

namespace TaskMasterApp.Interfaces
{
    public interface IRepository
    {
        Task<List<TaskItem>> GetAll();
        Task<TaskItem> GetById(int id);
        Task Post(TaskItem entity);
        Task Update(TaskItem entity);
        Task Delete(int id);
    }
}
