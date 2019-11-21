using System;
using System.Collections.Generic;
using System.Text;

namespace DSN.Common.Types
{
    public interface IIdentifiable
    {
        Guid Id { get; }
    }
}
