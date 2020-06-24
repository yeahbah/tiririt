using IdentityServer4.Extensions;
using System.Linq;
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

        public int? GetUserId()
        {
            var identity = (ClaimsIdentity)this.principal.Identity;
            if (identity.Claims.Count() == 0) return null;
            var result = identity.GetSubjectId();
            
            return int.Parse(result);            
        }
    }
}
