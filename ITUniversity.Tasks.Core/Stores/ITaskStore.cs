using ITUniversity.Tasks.Entities;

namespace ITUniversity.Tasks.Stores
{
    /// <summary>
    /// Хранилище для сущности <see cref="TaskBase"/>
    /// </summary>
    public interface ITaskStore
    {
        /// <summary>
        /// Сохранить
        /// </summary>
        /// <param name="task">Задача</param>
        TaskBase Save(TaskBase task);

        /// <summary>
        /// Обновить
        /// </summary>
        /// <param name="task">Задача</param>
        TaskBase Update(TaskBase task);

        /// <summary>
        /// Получить
        /// </summary>
        /// <param name="id">Идентификатор</param>
        TaskBase Get(long id);

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="id">Идентификатор</param>
        void Delete(long id);
    }
}