using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DSN.Common.Authentication
{
    public interface IAccessTokenService
    {
        Task<bool> IsCurrentActiveToken();
        Task DeactivateCurrentAsync(string userId);
        Task<bool> IsActiveAsync(string token);
        Task DeactivateAsync(string userId, string token);
    }
}
