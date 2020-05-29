using Microsoft.AspNetCore.Mvc;

namespace Tiririt.Web.Controllers
{
    [Route("api/v1/[controller]")]
    public class TiriritControllerBase : ControllerBase
    {
        protected IActionResult OkOrNotFound<T>(T data)
        {
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        protected ActionResult<T> OkOrNotFoundOf<T>(T data)
        {
            if (data == null)
            {
                return NotFound();                
            }

            return Ok(data);
        }
    }

}