using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Tiririt.Data.Entities;

namespace Tiririt.Web.Controllers.Identity.Account
{
    [Authorize(Policy = "Admin")]
    //[Authorize]
    public class ClaimsController : Controller
    {
        private readonly UserManager<TIRIRIT_USER> userManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;

        public ClaimsController(UserManager<TIRIRIT_USER> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public ViewResult Index()
        {
            return View(User?.Claims);
        }

        public ViewResult Create() => View();

        public ViewResult CreateRole() => View();

        public ViewResult AddToRole() => View();

        [HttpPost]        
        [ActionName("Create")]
        public async Task<IActionResult> CreateClaim(string claimType, string claimValue)
        {
            var user = await this.userManager.GetUserAsync(HttpContext.User);
            var claim = new Claim(claimType, claimValue, ClaimValueTypes.String);
            var result = await this.userManager.AddClaimAsync(user, claim);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            } 
            else
            {
                Errors(result);
            }

            return View("Index");
        }

        [HttpPost]
        [ActionName("CreateRole")]
        public async Task<IActionResult> CreateRole(string roleValue)
        {
            var result = await this.roleManager.CreateAsync(new IdentityRole<int>(roleValue));
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                Errors(result);
            }
            return View("Index");
        }

        [HttpPost]
        [ActionName("AddToRole")]
        public async Task<IActionResult> AddToRole(string role)
        {
            var user = await this.userManager.GetUserAsync(HttpContext.User);
            var result = await this.userManager.AddToRoleAsync(user, role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                Errors(result);
            }

            return View("Index");
        }

        private void Errors(IdentityResult result)
        {
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
    }
}
