using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using ITUniversity.Domain.Entities;

namespace ITUniversity.Domain.Repositories.Impls
{
    /// <summary>
    /// Базовый репозиторий
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности</typeparam>
    /// <typeparam name="TPrimaryKey">Тип первичного ключа</typeparam>
    public abstract class RepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        /// <inheritdoc/>
        public abstract IQueryable<TEntity> GetAll();

        /// <inheritdoc/>
        public virtual IList<TEntity> GetAllList()
        {
            return GetAll().ToList();
        }

        /// <inheritdoc/>
        public virtual TEntity Get(TPrimaryKey id)
        {
            var entity = FirstOrDefault(id);
            if (entity == null)
            {
                throw new Exception($"Сущность с id: {id}, не найдена");
            }

            return entity;
        }

        /// <inheritdoc/>
        public virtual TEntity FirstOrDefault(TPrimaryKey id)
        {
            return GetAll().FirstOrDefault(CreateEqualityExpressionForId(id));
        }

        /// <inheritdoc/>
        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().FirstOrDefault(predicate);
        }

        /// <inheritdoc/>
        public abstract TEntity Save(TEntity entity);

        /// <inheritdoc/>
        public abstract TEntity Update(TEntity entity);

        /// <inheritdoc/>
        public abstract void Delete(TPrimaryKey id);

        protected virtual Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TPrimaryKey id)
        {
            var lambdaParam = Expression.Parameter(typeof(TEntity));

            var leftExpression = Expression.PropertyOrField(lambdaParam, "Id");

            var idValue = Convert.ChangeType(id, typeof(TPrimaryKey));

            Expression<Func<object>> closure = () => idValue;
            var rightExpression = Expression.Convert(closure.Body, leftExpression.Type);

            var lambdaBody = Expression.Equal(leftExpression, rightExpression);

            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }
    }
}
