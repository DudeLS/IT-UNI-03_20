using System.Threading.Tasks;

using ITUniversity.Domain.Repositories;
using ITUniversity.Tasks.Entities;

namespace ITUniversity.Tasks.Repositories
{
    /// <summary>
    /// Репозиторий сущности <see cref="User"/>
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Получить пользователя (с учетом блокированных) или null
        /// </summary>
        /// <param name="login">Логин</param>
        Task<User> FirstOrDefaultWithBlockAsync(string login);
    }
}