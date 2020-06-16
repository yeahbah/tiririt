using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tiririt.Web.Controllers
{
    [Authorize]
    public class SecretController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
