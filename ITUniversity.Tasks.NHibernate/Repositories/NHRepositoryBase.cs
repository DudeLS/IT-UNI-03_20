using System;
using System.Linq;

using ITUniversity.Domain.Entities;
using ITUniversity.Domain.Repositories.Impls;
using NHibernate;

namespace ITUniversity.Tasks.NHibernate.Repositories
{
    /// <summary>
    /// Базовый репозиторий NHibernate
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности</typeparam>
    /// <typeparam name="TPrimaryKey">Тип первичного ключа</typeparam>
    public class NhRepositoryBase<TEntity, TPrimaryKey> : RepositoryBase<TEntity, TPrimaryKey>, IDisposable
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public virtual ISession Session { get; }

        //private readonly ITransaction transaction;

        /// <summary>
        /// Инициализировать экземпляр <see cref="NhRepositoryBase{TEntity, TPrimaryKey}"/>
        /// </summary>
        /// <param name="session">Сессия NHibernate</param>
        public NhRepositoryBase(ISession session)
        {
            Session = session;
            //transaction = Session.BeginTransaction();
        }

        /// <inheritdoc/>
        public override IQueryable<TEntity> GetAll()
        {
            return Session.Query<TEntity>();
        }

        /// <inheritdoc/>
        public override TEntity FirstOrDefault(TPrimaryKey id)
        {
            return Session.Get<TEntity>(id);
        }

        /// <inheritdoc/>
        public override TEntity Save(TEntity entity)
        {
            Session.Save(entity);
            Session.Flush(); //Не правильно, только для тестов работы приложения
            return entity;
        }

        /// <inheritdoc/>
        public override TEntity Update(TEntity entity)
        {
            Session.Update(entity);
            Session.Flush(); //Не правильно, только для тестов работы приложения
            return entity;
        }

        /// <inheritdoc/>
        public override void Delete(TPrimaryKey id)
        {
            var entity = Session.Load<TEntity>(id);
            Session.Delete(entity);
            Session.Flush(); //Не правильно, только для тестов работы приложения
        }

        public void Dispose()
        {
            //transaction.Commit();
        }
    }
}