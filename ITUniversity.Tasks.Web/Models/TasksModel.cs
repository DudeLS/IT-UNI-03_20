using System.Collections.Generic;

using ITUniversity.Tasks.API.Services.Dto;

namespace ITUniversity.Tasks.Web.Models
{
    public class TasksModel
    {
        public ICollection<TaskDto> Incoming
        {
            get;
            set;
        }

        public ICollection<TaskDto> Outgoing
        {
            get;
            set;
        }
    }
}