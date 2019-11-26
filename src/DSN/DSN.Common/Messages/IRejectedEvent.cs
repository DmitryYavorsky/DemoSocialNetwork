using System;
using System.Collections.Generic;
using System.Text;

namespace DSN.Common.Messages
{
    public interface IRejectedEvent: IEvent
    {
        string Reason { get; set; }
        string Code { get; set; }
    }
}
