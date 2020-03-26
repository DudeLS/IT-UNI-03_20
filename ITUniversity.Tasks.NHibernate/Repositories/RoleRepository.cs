using ITUniversity.Tasks.Entities;
using ITUniversity.Tasks.Repositories;

using NHibernate;

namespace ITUniversity.Tasks.NHibernate.Repositories
{
    /// <summary>
    /// Репозиторий сущности <see cref="Role"/>
    /// </summary>
    public class RoleRepository : NhRepositoryBase<Role, int>, IRoleRepository
    {
        /// <summary>
        /// Инициализировать экземпляр <see cref="RoleRepository"/>
        /// </summary>
        /// <param name="session">Сессия NHibernate</param>
        public RoleRepository(ISession session)
            : base(session)
        {

        }
    }
}