using System;
using System.Collections.Generic;
using System.Text;
using DSN.Common.Types;

namespace DSN.Common.RabbitMq
{
    public interface IBusSubscriber
    {
        //IBusSubscriber SubscribeCommand<TCommand>(string @namespace = null,string queueName=null, Func<TCommand, DSNException, >)
    }
}
