using System.Linq;
using System.Security.Claims;

namespace ITUniversity.Runtime.Session
{
    /// <summary>
    /// 
    /// </summary>
    public class ClaimsAppSession : IAppSession
    {
        private readonly IPrincipalAccessor principalAccessor;

        /// <summary>
        /// Инициализировать экземпляр <see cref="ClaimsAppSession"/>
        /// </summary>
        /// <param name="principalAccessor"></param>
        public ClaimsAppSession(IPrincipalAccessor principalAccessor)
        {
            this.principalAccessor = principalAccessor;
        }

        /// <inheritdoc/>
        public string UserLogin
        {
            get
            {
                var userNameClaim = principalAccessor.Principal?.Claims.FirstOrDefault(c => c.Type == ClaimsIdentity.DefaultNameClaimType);
                return userNameClaim?.Value;
            }
        }
    }
}