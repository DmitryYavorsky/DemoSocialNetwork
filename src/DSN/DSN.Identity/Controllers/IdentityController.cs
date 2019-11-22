using System.Threading.Tasks;
using DSN.Common.Authentication;
using DSN.Identity.Messages.Commands;
using DSN.Identity.Services;
using Microsoft.AspNetCore.Mvc;

namespace DSN.Identity.Controllers
{
    [Route("")]
    [ApiController]
    public class IdentityController : BaseController
    {
        private readonly IIdentityService _identityService;
        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        [HttpGet("me")]
        [JwtAuth]
        public IActionResult Get() => Content($"Your id is {UserId}.");

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn(SignIn command)
            => Ok(await _identityService.SignInAsync(command.Email, command.Password));

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp(SignUp command)
        {
            await _identityService.SignUpAsync(command.Id, command.Email, command.Password, command.Role);
            return NoContent();
        }



    }
}