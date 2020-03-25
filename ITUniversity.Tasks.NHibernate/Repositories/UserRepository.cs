using System.Linq;
using System.Threading.Tasks;

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

        /// <inheritdoc/>
        public override IQueryable<User> GetAll()
        {
            return base.GetAll().Where(e => !e.IsBlocked);
        }

        /// <inheritdoc/>
        public virtual async Task<User> FirstOrDefaultWithBlockAsync(string login)
        {
            return await Task.FromResult(Session.Query<User>().FirstOrDefault(u => u.Login == login));
        }
    }
}