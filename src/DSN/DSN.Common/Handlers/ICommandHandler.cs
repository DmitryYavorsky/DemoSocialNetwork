using System;
using System.Collections.Generic;
using System.Text;
using DSN.Common.Messages;

namespace DSN.Common.Handlers
{
    public interface ICommandHandler<in TCommand> where TCommand: ICommand
    {
    }
}
