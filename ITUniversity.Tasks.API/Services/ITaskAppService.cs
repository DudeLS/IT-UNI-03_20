using System.Collections.Generic;

using ITUniversity.Application.Services;
using ITUniversity.Tasks.API.Services.Dto;

namespace ITUniversity.Tasks.API.Services
{
    /// <summary>
    /// Сервис для работы с задачами
    /// </summary>
    public interface ITaskAppService : IApplicationService
    {
        /// <summary>
        /// Создать задачу
        /// </summary>
        /// <param name="dto"></param>
        TaskDto Create(CreateTaskDto dto);

        /// <summary>
        /// Обновить задачу
        /// </summary>
        /// <param name="dto"></param>
        TaskDto Update(UpdateTaskDto dto);

        /// <summary>
        /// Удалить задачу
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        void Delete(long id);

        /// <summary>
        /// Получить задачу
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        TaskDto Get(long id);

        /// <summary>
        /// Получить все задачи
        /// </summary>
        ICollection<TaskDto> GetAll();
    }
}