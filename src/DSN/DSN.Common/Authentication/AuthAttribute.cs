

using Microsoft.AspNetCore.Authorization;

namespace DSN.Common.Authentication
{
    public class AuthAttribute : AuthorizeAttribute
    {
        public AuthAttribute(string scheme, string policy): base(policy)
        {
            AuthenticationSchemes = scheme;
        }
    }
}
