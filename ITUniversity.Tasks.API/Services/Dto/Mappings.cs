using AutoMapper;

using ITUniversity.Tasks.Entities;

namespace ITUniversity.Tasks.API.Services.Dto
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<TaskBase, TaskDto>();
            CreateMap<CreateTaskDto, TaskBase>();
            CreateMap<UpdateTaskDto, TaskBase>();
            CreateMap<CreateUserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}