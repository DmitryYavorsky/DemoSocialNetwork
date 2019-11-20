using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSN.Common.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSN.Identity.Controllers
{
    [Route("")]
    [ApiController]
    public class IdentityController : BaseController
    {
        public IdentityController()
        {
            
        }
        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn()
        {
            return NoContent();
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp()
        {
            return NoContent();
        }
        
        [HttpGet("me")]
        [JwtAuth]
        public IActionResult Get() => Content($"Your id is {UserId}.");



    }
}