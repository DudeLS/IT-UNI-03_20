using ITUniversity.Tasks.Entities;
using ITUniversity.Tasks.Repositories;

using NHibernate;

namespace ITUniversity.Tasks.NHibernate.Repositories
{
    /// <summary>
    /// Репозиторий сущности <see cref="User"/>
    /// </summary>
    public class UserRepository : NhRepositoryBase<User, int>, IUserRepository
    {
        /// <summary>
        /// Инициализировать экземпляр <see cref="UserRepository"/>
        /// </summary>
        /// <param name="session">Сессия NHibernate</param>
        public UserRepository(ISession session) 
            : base(session)
        {

        }
    }
}