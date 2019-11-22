using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSN.Identity.Services
{
    public interface IClaimsProvider
    {
        Task<IDictionary<string, string>> GetAsync(Guid userId);
    }
}
