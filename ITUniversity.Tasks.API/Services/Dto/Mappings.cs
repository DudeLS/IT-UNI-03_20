using AutoMapper;

using ITUniversity.Tasks.Entities;

namespace ITUniversity.Tasks.API.Services.Dto
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<TaskBase, TaskDto>();
            CreateMap<TaskCreateDto, TaskBase>();
            CreateMap<TaskUpdateDto, TaskBase>();
        }
    }
}