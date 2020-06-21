using IdentityServer4.Extensions;
using System.Security.Claims;
using System.Security.Principal;


namespace Tiririt.Core.Identity
{
    public class CurrentPrincipal : ICurrentPrincipal
    {
        private readonly ClaimsPrincipal principal;

        public CurrentPrincipal(IPrincipal principal)
        {
            this.principal = principal as ClaimsPrincipal;
        }

        public int GetUserId()
        {
            var identity = (ClaimsIdentity)this.principal.Identity;
            return int.Parse(identity.GetSubjectId());            
        }
    }
}
