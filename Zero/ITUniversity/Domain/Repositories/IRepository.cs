using System.Collections.Generic;
using System.Linq;

namespace ITUniversity.Domain.Repositories
{
    /// <summary>
    /// Репозиторий сущности
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Сохранить
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Save(TEntity entity);

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);

        /// <summary>
        /// Обновить
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Update(TEntity entity);

        /// <summary>
        /// Получить все
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Получить все
        /// </summary>
        /// <returns></returns>
        ICollection<TEntity> GetAllList();

        /// <summary>
        /// Получить
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Get(long id);
    }
}