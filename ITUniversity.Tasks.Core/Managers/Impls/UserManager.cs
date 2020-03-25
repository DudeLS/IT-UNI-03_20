using System.Threading.Tasks;

using ITUniversity.Tasks.Repositories;

namespace ITUniversity.Tasks.Managers.Impls
{
    /// <summary>
    /// Менеджер сущности <see cref="User"/>
    /// </summary>
    public class UserManager : IUserManager
    {
        private readonly IUserRepository userRepository;

        /// <summary>
        /// Инициализировать экземпляр <see cref="UserManager"/>
        /// </summary>
        /// <param name="userRepository">Репозиторий пользователей</param>
        public UserManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <inheritdoc/>
        public async Task<bool> Block(int id)
        {
            var entity = await userRepository.GetAsync(id);
            entity.IsBlocked = true;
            await userRepository.UpdateAsync(entity);
            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> FreeLogin(string login)
        {
            var entity = await userRepository.FirstOrDefaultWithBlockAsync(login);
            return entity == null;
        }
    }
}