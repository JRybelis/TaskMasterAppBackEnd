using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TaskmasterCore.Dtos;

namespace TaskMasterApp.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<TaskDto, Task>().ReverseMap();
        }
    }
}
