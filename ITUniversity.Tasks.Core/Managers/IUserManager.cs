using System.Threading.Tasks;

using ITUniversity.Tasks.Entities;

namespace ITUniversity.Tasks.Managers
{
    /// <summary>
    /// Менеджер сущности <see cref="User"/>
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// Свободный логин
        /// </summary>
        /// <param name="login">Логин</param>
        Task<bool> FreeLogin(string login);

        /// <summary>
        /// Заблокировать пользователя
        /// </summary>
        /// <param name="id">Иденитификатор пользователя</param>
        Task<bool> Block(int id);
    }
}