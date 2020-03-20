using System.Collections.Generic;

using ITUniversity.Tasks.Entities;

namespace ITUniversity.Tasks.Managers
{
    /// <summary>
    /// Менеджер сущности <see cref="TaskBase"/>
    /// </summary>
    public interface ITaskManager
    {
        /// <summary>
        /// Создание задачи
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        TaskBase Create(TaskBase task);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        TaskBase Create(string subject);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TaskBase Get(long id);

        /// <summary>
        /// Получить все
        /// </summary>
        /// <returns></returns>
        ICollection<TaskBase> GetAll();

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="id">Идентификатор</param>
        void Delete(long id);
    }
}