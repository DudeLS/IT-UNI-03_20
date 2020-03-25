using ITUniversity.Domain.Repositories;
using ITUniversity.Tasks.Entities;

namespace ITUniversity.Tasks.Repositories
{
    /// <summary>
    /// Репозиторий сущности <see cref="User"/>
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
    }
}