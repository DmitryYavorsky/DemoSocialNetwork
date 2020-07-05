using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSN.ApiGetWay.Messages.Commands.Accounts;
using DSN.Common.RabbitMq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;

namespace DSN.ApiGetWay.Controllers
{
    [AllowAnonymous]
    public class AccountsController : BaseController
    {
       
        public AccountsController(IBusPublisher busPublisher, ITracer tracer) : base(busPublisher, tracer)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateAccount command)
            => await SendAsync(command, resourceId: command.Id, resource:"accounts");
    }
}