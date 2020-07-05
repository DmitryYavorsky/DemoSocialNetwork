using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RawRabbit;
using RawRabbit.Enrichers.MessageContext;

namespace DSN.Common.RabbitMq
{
    public class BusPublisher : IBusPublisher
    {
        private readonly IBusClient _busClient;
        public BusPublisher(IBusClient busClient)
        {
            _busClient = busClient;
        }
        public async Task PublishAsync<TEvent>(TEvent @event, ICorrelationContext context) where TEvent : INotification
            => await _busClient.PublishAsync(@event, ctx => ctx.UseMessageContext(context));

        public async Task SendAsync<TCommand>(TCommand command, ICorrelationContext context) where TCommand : IRequest
            => await _busClient.PublishAsync(command, ctx => ctx.UseMessageContext(context));
    }
}
