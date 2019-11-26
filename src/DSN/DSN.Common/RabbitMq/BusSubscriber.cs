using System;
using System.Collections.Generic;
using System.Text;
using DSN.Common.Messages;
using DSN.Common.Types;
using Microsoft.AspNetCore.Builder;
using RawRabbit;

namespace DSN.Common.RabbitMq
{
    public class BusSubscriber: IBusSubscriber
    {
        private readonly IBusClient _busClient;
        public BusSubscriber(IBusClient busClient)
        {
            _busClient = busClient;
        }

        public BusSubscriber(IApplicationBuilder app)
        {

        }
        public IBusSubscriber SubscribeCommand<TCommand>(string @namespace = null, string queueName = null, Func<TCommand, DSNException, IRejectedEvent> onError = null) where TCommand : ICommand
        {
            throw new NotImplementedException();
        }

        public IBusSubscriber SubscribeEvent<TEvent>(string @namespace = null, string queueName = null, Func<TEvent, DSNException, IRejectedEvent> onError = null) where TEvent : IEvent
        {
            throw new NotImplementedException();
        }
    }
}
