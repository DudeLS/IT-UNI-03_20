using System.Security.Claims;

using ITUniversity.Runtime.Session;

using Microsoft.AspNetCore.Http;

namespace ITUniversity.AspNetCore.Runtime.Session
{
    public class AspNetCorePrincipalAccessor : DefaultPrincipalAccessor
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public AspNetCorePrincipalAccessor(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public override ClaimsPrincipal Principal
        {
            get { return httpContextAccessor.HttpContext?.User ?? base.Principal; }
        }
    }
}