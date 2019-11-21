using System;
using System.Collections.Generic;
using System.Text;

namespace DSN.Common.Mvc
{
    public class ServiceId: IServiceId
    {
        private static readonly string UniqueId = $"{Guid.NewGuid():N}";
        public string Id => UniqueId;
    }
}
