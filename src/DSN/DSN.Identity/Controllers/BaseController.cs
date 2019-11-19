using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSN.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected bool IsAdming => User.IsInRole("SomeRole");

        protected Guid UserId => string.IsNullOrWhiteSpace(User?.Identity?.Name) ? Guid.Empty : Guid.Parse(User.Identity.Name);
    }
}