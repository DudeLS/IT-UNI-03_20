using System.Security.Claims;
using System.Threading;

namespace ITUniversity.Runtime.Session
{
    public class DefaultPrincipalAccessor : IPrincipalAccessor
    {
        public virtual ClaimsPrincipal Principal
        {
            get { return Thread.CurrentPrincipal as ClaimsPrincipal; }
        }
    }
}