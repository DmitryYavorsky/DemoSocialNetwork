using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSN.Common.Messages;
using RawRabbit;

namespace DSN.Common.RabbitMq
{
    public class BusPublisher: IBusPublisher
    {
        private readonly IBusClient _busClient;

        public BusPublisher(IBusClient busClient)
        {
            _busClient = busClient;
        }

        public async Task SendAsync<TCommand>(TCommand command, ICorrelationContext context) where TCommand : ICommand
            => await _busClient.PublishAsync(command);

            public Task PublishAsync<TEvent>(TEvent @event, ICorrelationContext context) where TEvent : IEvent
        {
            throw new NotImplementedException();
        }
    }
}
