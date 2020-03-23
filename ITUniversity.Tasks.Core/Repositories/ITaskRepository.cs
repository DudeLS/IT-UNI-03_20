using ITUniversity.Domain.Repositories;
using ITUniversity.Tasks.Entities;

namespace ITUniversity.Tasks.Repositories
{
    public interface ITaskRepository : IRepository<TaskBase>
    {
        //TaskBase Create(TaskBase task);

        //ICollection<TaskBase> GetAll();
    }
}