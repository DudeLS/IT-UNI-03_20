using ITUniversity.Domain.Repositories;
using ITUniversity.Tasks.Entities;

namespace ITUniversity.Tasks.Repositories
{
    /// <summary>
    /// Репозиторий сущности <see cref="TaskBase"/>
    /// </summary>
    public interface ITaskRepository : IRepository<TaskBase, long>
    {

    }
}