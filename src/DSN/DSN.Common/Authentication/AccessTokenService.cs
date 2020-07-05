using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace DSN.Common.Authentication
{
    public class AccessTokenService: IAccessTokenService
    {
        private readonly IOptions<JwtOptions> _options;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AccessTokenService(IOptions<JwtOptions> options, IHttpContextAccessor httpContextAccessor)
        {
            _options = options;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<bool> IsCurrentActiveToken()
        {
             return await Task.FromResult(true);
        }

        public Task DeactivateCurrentAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsActiveAsync(string token)
        {
            throw new NotImplementedException();
        }

        public Task DeactivateAsync(string userId, string token)
        {
            throw new NotImplementedException();
        }

        private string GetCurrentAsync()
        {
            var authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["authorization"];
            return authorizationHeader == StringValues.Empty
                ? string.Empty
                : authorizationHeader.Single().Split(' ').Last();
        }
        private static string GetKey(string token)
            => $"token:{token}";
    }
}
