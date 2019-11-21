using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSN.Common.Types;

namespace DSN.Identity.Domain
{
    public class RefreshToken : IIdentifiable
    {
        public Guid Id { get; private set; }
    }
}
