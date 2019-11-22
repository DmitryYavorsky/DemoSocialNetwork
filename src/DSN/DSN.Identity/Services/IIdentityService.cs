using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSN.Common.Authentication;
using DSN.Identity.Domain;


namespace DSN.Identity.Services
{
    public interface IIdentityService
    {
        Task SignUpAsync(Guid id, string email, string password, string role = Role.User);
        Task<JsonWebToken> SignInAsync(string email, string password);
        Task ChangePasswordAsync(Guid userId, string currentPassword, string newPassword);
    }
}
