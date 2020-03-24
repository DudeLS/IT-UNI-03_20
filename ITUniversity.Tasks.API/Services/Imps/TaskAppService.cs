using AutoMapper;

using ITUniversity.Application.Services;
using ITUniversity.Tasks.API.Services.Dto;
using ITUniversity.Tasks.Managers;

namespace ITUniversity.Tasks.API.Services.Imps
{
    public class TaskAppService : ApplicationService, ITaskAppService
    {
        private readonly ITaskManager taskManager;

        private readonly IMapper mapper;

        public TaskAppService(ITaskManager taskManager, IMapper mapper)
        {
            this.taskManager = taskManager;
            this.mapper = mapper;
        }

        public TaskDto Get(long id)
        {
            var entity = taskManager.Get(id);
            var dto = mapper.Map<TaskDto>(entity);
            return dto;
        }

        public TaskDto Create(TaskCreateDto task)
        {
            throw new System.NotImplementedException();
        }

        public TaskDto Update(TaskUpdateDto task)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}