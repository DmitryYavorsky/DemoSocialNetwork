using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSN.Common.RabbitMq;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;

namespace DSN.ApiGetWay.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private static readonly string AcceptLanguageHeader = "accept-language";
        private static readonly string OperationHeader = "X-Operation";
        private static readonly string ResourceHeader = "X-Resource";
        private static readonly string DefaultCulture = "en-us";
        private readonly IBusPublisher _busPublisher;
        private readonly ITracer _tracer;
        public BaseController(IBusPublisher busPublisher, ITracer tracer)
        {
            _busPublisher = busPublisher;
            _tracer = tracer;
        }

        protected IActionResult Single<T>(T model, Func<T, bool> criteria = null)
        {
            if (model == null)
            {
                return NotFound();
            }

            var isValid = criteria == null || criteria(model);
            if (isValid)
            {
                return Ok(model);
            }

            return NotFound();
        }

        protected async Task<IActionResult> SendAsync<T>(T command,
          Guid? resourceId = null, string resource = "") where T : IRequest
        {
            var context = GetContext<T>(resourceId, resource);
            await _busPublisher.SendAsync(command, context);

            return Accepted(context);
        }

        protected ICorrelationContext GetContext<T>(Guid? resourceId = null, string resource = "") where T : IRequest
        {
            if (!string.IsNullOrWhiteSpace(resource))
            {
                resource = $"{resource}/{resourceId}";
            }

            return CorrelationContext.Create<T>(Guid.NewGuid(), UserId, resourceId ?? Guid.Empty,
               HttpContext.TraceIdentifier,
               Request.Path.ToString(), Culture, resource);
        }

        protected Guid UserId => string.IsNullOrWhiteSpace(User?.Identity.Name)
            ? Guid.Empty
            : Guid.Parse(User.Identity.Name);
        protected string Culture
           => Request.Headers.ContainsKey(AcceptLanguageHeader) ?
                   Request.Headers[AcceptLanguageHeader].First().ToLowerInvariant() :
                   DefaultCulture;
    }
}