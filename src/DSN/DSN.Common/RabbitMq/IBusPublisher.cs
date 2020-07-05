using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace DSN.Common.RabbitMq
{
    public interface IBusPublisher
    {
        Task SendAsync<TCommand>(TCommand command, ICorrelationContext context) where TCommand : IRequest;
        Task PublishAsync<TEvent>(TEvent @event, ICorrelationContext context) where TEvent : INotification;
    }
}
