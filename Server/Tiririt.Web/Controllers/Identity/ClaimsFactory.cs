using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Tiririt.Data.Entities;
using Tiririt.Data.Internal;

namespace Tiririt.Web.Controllers.Identity
{
    public class ClaimsFactory : UserClaimsPrincipalFactory<TIRIRIT_USER>
    {
        private readonly UserManager<TIRIRIT_USER> userManager;
        private readonly TiriritDbContext dbContext;

        public ClaimsFactory(
            UserManager<TIRIRIT_USER> userManager, 
            IOptions<IdentityOptions> optionsAccessor,
            TiriritDbContext dbContext) : base(userManager, optionsAccessor)
        {
            this.userManager = userManager;
            this.dbContext = dbContext;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(TIRIRIT_USER user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            var roles = await this.userManager.GetRolesAsync(user);

            //identity.AddClaim(new Claim(JwtClaimTypes.Subject, user.Id.ToString()));
            identity.AddClaims(roles.Select(role => new Claim(JwtClaimTypes.Role, role)));

            return identity;
        }
    }
}
