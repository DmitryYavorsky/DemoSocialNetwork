using DSN.Common.Messages;
using DSN.Common.Types;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DSN.Common.RabbitMq
{
    public interface IBusSubscriber
    {
        Task SubscribeCommand<TCommand>(string @namespace = null, string queueName = null, Func<TCommand, DSNException, IRejectedEvent> onError = null)
            where TCommand : IRequest;
        Task SubscribeEvent<TEvent>(string @namespace = null, string queueName = null, Func<TEvent, DSNException, IRejectedEvent> onError = null) 
            where TEvent : INotification;
    }
}
