using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using ITUniversity.Domain.Entities;

namespace ITUniversity.Domain.Repositories
{
    /// <summary>
    /// Репозиторий
    /// </summary>
    /// <typeparam name="TEntity">Тип сущность</typeparam>
    /// <typeparam name="TPrimaryKey">Тип первичного ключа</typeparam>
    public interface IRepository<TEntity, TPrimaryKey> : IRepository 
        where TEntity : class, IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Сохранить
        /// </summary>
        /// <param name="entity">Сохраняемая сущность</param>
        TEntity Save(TEntity entity);

        /// <summary>
        /// Обновить существующую сущность
        /// </summary>
        /// <param name="entity">Обновляемая сущность</param>
        TEntity Update(TEntity entity);

        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <param name="id">Идентификатор удаляемой сущность</param>
        void Delete(TPrimaryKey id);

        /// <summary>
        /// Получить все сущности
        /// </summary>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Получить все сущности
        /// </summary>
        IList<TEntity> GetAllList();

        /// <summary>
        /// Получить сущность
        /// </summary>
        /// <param name="id">Идентификатор</param>
        TEntity Get(TPrimaryKey id);

        /// <summary>
        /// Получить сущность или null
        /// </summary>
        /// <param name="id">Идентификатор</param>
        TEntity FirstOrDefault(TPrimaryKey id);

        /// <summary>
        /// Получить сущность или null
        /// </summary>
        /// <param name="predicate">Условие</param>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
    }
}