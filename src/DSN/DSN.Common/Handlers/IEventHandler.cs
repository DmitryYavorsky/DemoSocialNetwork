using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSN.Common.Messages;
using DSN.Common.RabbitMq;

namespace DSN.Common.Handlers
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task HandleAsync(TEvent @event, ICorrelationContext context);
    }
}
