using System.Collections.Generic;

using AutoMapper;

using ITUniversity.Application.Services;
using ITUniversity.Tasks.API.Services.Dto;
using ITUniversity.Tasks.Entities;
using ITUniversity.Tasks.Managers;

namespace ITUniversity.Tasks.API.Services.Imps
{
    /// <summary>
    /// Сервис для работы с задачами
    /// </summary>
    public class TaskAppService : ApplicationService, ITaskAppService
    {
        private readonly ITaskManager taskManager;

        private readonly IMapper mapper;

        /// <summary>
        /// Инициализировать экземпляр <see cref="TaskAppService"/>
        /// </summary>
        /// <param name="taskManager">Менеджер для работы с задачами</param>
        /// <param name="mapper">Маппер</param>
        public TaskAppService(ITaskManager taskManager, IMapper mapper)
        {
            this.taskManager = taskManager;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public TaskDto Get(long id)
        {
            var entity = taskManager.Get(id);
            var dto = mapper.Map<TaskDto>(entity);
            return dto;
        }

        /// <inheritdoc/>
        public ICollection<TaskDto> GetAll()
        {
            var entities = taskManager.GetAll();
            var dtos = mapper.Map<ICollection<TaskDto>>(entities);
            return dtos;
        }

        /// <inheritdoc/>
        public TaskDto Create(CreateTaskDto createDto)
        {
            var entity = mapper.Map<TaskBase>(createDto);
            taskManager.Create(entity);
            var dto = mapper.Map<TaskDto>(entity);
            return dto;
        }

        /// <inheritdoc/>
        public TaskDto Update(UpdateTaskDto updateDto)
        {
            var entity = mapper.Map<TaskBase>(updateDto);
            taskManager.Update(entity);
            var dto = mapper.Map<TaskDto>(entity);
            return dto;
        }

        /// <inheritdoc/>
        public void Delete(long id)
        {
            taskManager.Delete(id);
        }
    }
}