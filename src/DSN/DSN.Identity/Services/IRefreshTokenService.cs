using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSN.Common.Authentication;

namespace DSN.Identity.Services
{
    public interface IRefreshTokenService
    {
        Task AddAsync(Guid userId);
        Task<JsonWebToken> CreateAccessTokenAsync(string refreshToken);
        Task RevokeToken(string refreshToken, Guid userId);
    }
}
