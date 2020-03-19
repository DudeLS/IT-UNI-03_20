using AutoMapper;

using ITUniversity.Tasks.Entities;
using ITUniversity.Tasks.Web.Models;

namespace ITUniversity.Tasks.Web
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<TaskCreateModel, TaskBase>();
        }
    }
}