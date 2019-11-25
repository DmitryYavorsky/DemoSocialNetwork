using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSN.Identity.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected bool IsAdmin => User.IsInRole("admin");

        protected Guid UserId => string.IsNullOrWhiteSpace(User?.Identity?.Name) ? Guid.Empty : Guid.Parse(User.Identity.Name);
    }
}