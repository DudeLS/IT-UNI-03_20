using System.Collections.Generic;
using System.Linq;
using ITUniversity.Tasks.Entities;
using ITUniversity.Tasks.Repositories;

using NHibernate;

namespace ITUniversity.Tasks.NHibernate.Repositories
{
    //public class TaskRepository : ITaskRepository
    //{
    //    private readonly ISession session;

    //    public TaskRepository(ISession session)
    //    {
    //        this.session = session;
    //    }

    //    public TaskBase Create(TaskBase task)
    //    {
    //        session.Save(task);
    //        session.Flush();
    //        return task;
    //    }

    //    public ICollection<TaskBase> GetAll()
    //    {
    //        return session.Query<TaskBase>().ToList();
    //    }
    //}
}