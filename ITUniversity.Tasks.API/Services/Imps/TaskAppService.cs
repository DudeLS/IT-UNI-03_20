using System.Collections.Generic;
using AutoMapper;

using ITUniversity.Application.Services;
using ITUniversity.Tasks.API.Services.Dto;
using ITUniversity.Tasks.Entities;
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

        public ICollection<TaskDto> GetAll()
        {
            var entities = taskManager.GetAll();
            var dtos = mapper.Map<ICollection<TaskDto>>(entities);
            return dtos;
        }

        public TaskDto Create(TaskCreateDto createDto)
        {
            var entity = mapper.Map<TaskBase>(createDto);
            taskManager.Create(entity);
            var dto = mapper.Map<TaskDto>(entity);
            return dto;
        }

        public TaskDto Update(TaskUpdateDto updateDto)
        {
            var entity = mapper.Map<TaskBase>(updateDto);
            taskManager.Update(entity);
            var dto = mapper.Map<TaskDto>(entity);
            return dto;
        }

        public void Delete(long id)
        {
            taskManager.Delete(id);
        }
    }
}