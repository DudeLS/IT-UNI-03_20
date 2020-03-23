using System.Collections.Generic;
using System.Linq;

using ITUniversity.Tasks.Entities;
using ITUniversity.Tasks.Repositories;

using NHibernate;

namespace ITUniversity.Tasks.NHibernate.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ISession session;

        public TaskRepository(ISession session)
        {
            this.session = session;
        }

        public void Delete(long id)
        {
            var entity = GetAll().FirstOrDefault(e => e.Id == id);
            session.Delete(entity);
            session.Flush();
        }

        public TaskBase Get(long id)
        {
            return GetAll().FirstOrDefault(e => e.Id == id);
        }

        public IQueryable<TaskBase> GetAll()
        {
            return session.Query<TaskBase>();
        }

        public ICollection<TaskBase> GetAllList()
        {
            return GetAll().ToList();
        }

        public TaskBase Save(TaskBase entity)
        {
            session.Save(entity);
            session.Flush();

            return entity;
        }

        public TaskBase Update(TaskBase entity)
        {
            session.Update(entity);
            session.Flush();

            return entity;
        }
    }
}