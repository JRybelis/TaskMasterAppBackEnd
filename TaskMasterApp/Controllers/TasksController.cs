using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TaskMasterApp.Interfaces;
using TaskmasterCore.Dtos;
using TaskmasterCore.Models;

namespace TaskMasterApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public TasksController(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskItemDto>> GetAll()
        {
            var entities = await _repository.GetAll();

            return _mapper.Map<IEnumerable<TaskItemDto>>(entities);
        }

        [HttpGet("{id}")]
        public async Task<TaskItemDto> GetById(int id)
        {
            var entity = await _repository.GetById(id);

            return _mapper.Map<TaskItemDto>(entity);
        }

        [HttpPost]
        public async Task Upsert(TaskItemDto taskItemDto)
        {
            var entity = _mapper.Map<TaskItem>(taskItemDto);

            await _repository.Upsert(entity);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}
