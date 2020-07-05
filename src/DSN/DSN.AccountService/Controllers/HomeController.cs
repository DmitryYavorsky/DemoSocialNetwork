using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DSN.AccountService.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public IActionResult Get() => Ok("Accounts service works");
    }
}
