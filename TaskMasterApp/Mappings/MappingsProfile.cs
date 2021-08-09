using AutoMapper;
using TaskmasterCore.Dtos;
using TaskmasterCore.Models;

namespace TaskMasterApp.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<TaskItemDto, TaskItem>().ReverseMap();
        }
    }
}
