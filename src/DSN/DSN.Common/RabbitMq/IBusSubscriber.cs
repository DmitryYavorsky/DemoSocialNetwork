using System;
using System.Collections.Generic;
using System.Text;
using DSN.Common.Messages;
using DSN.Common.Types;

namespace DSN.Common.RabbitMq
{
    public interface IBusSubscriber
    {
        IBusSubscriber SubscribeCommand<TCommand>(string @namespace = null, string queueName = null,
            Func<TCommand, DSNException, IRejectedEvent> onError = null)
            where TCommand : ICommand;

        IBusSubscriber SubscribeEvent<TEvent>(string @namespace = null, string queueName = null,
            Func<TEvent, DSNException, IRejectedEvent> onError = null) where TEvent : IEvent;
    }
}
