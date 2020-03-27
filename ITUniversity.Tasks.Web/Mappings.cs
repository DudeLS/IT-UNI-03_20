using AutoMapper;

using ITUniversity.Tasks.API.Services.Dto;
using ITUniversity.Tasks.Entities;
using ITUniversity.Tasks.Web.Models;
using ITUniversity.Tasks.Web.Models.Account;

namespace ITUniversity.Tasks.Web
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<TaskCreateModel, TaskBase>();
            CreateMap<TaskBase, TaskEditModel>();
            CreateMap<TaskEditModel, TaskBase>();
            CreateMap<RegisterModel, CreateUserDto>();
            CreateMap<UserDto, UserEditModel>();
            CreateMap<TaskDto, TaskEditModel>().ForMember(dest => dest.Executor, opt => opt.MapFrom(exp => exp.Executor != null ? exp.Executor.Id : (int?)null));
        }
    }
}