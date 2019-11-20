using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace DSN.Common.Authentication
{
    public class JwtAuthAttribute: AuthAttribute
    {
        public JwtAuthAttribute(string policy = ""): base(JwtBearerDefaults.AuthenticationScheme,policy)
        {
            
        }
    }
}
