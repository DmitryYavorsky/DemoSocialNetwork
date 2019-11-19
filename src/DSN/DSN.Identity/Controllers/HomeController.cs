using Microsoft.AspNetCore.Mvc;

namespace DSN.Identity.Controllers
{
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("Identity Service Works");
    }
}