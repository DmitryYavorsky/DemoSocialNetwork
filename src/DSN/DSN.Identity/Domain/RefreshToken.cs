using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSN.Common.Types;
using Microsoft.AspNetCore.Identity;

namespace DSN.Identity.Domain
{
    public class RefreshToken : IIdentifiable
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public string Token { get;private set;}
        public DateTime CreatedAt { get; private set; }
        public DateTime? RevokedAt { get; private set; }
        public bool Revoked => RevokedAt.HasValue;

        public RefreshToken()
        {
            
        }

        public RefreshToken(User user, IPasswordHasher<User> passwordHasher)
        {
            Id = Guid.NewGuid();
            UserId = user.Id;
            CreatedAt = DateTime.UtcNow;
            Token = CreateToken(user, passwordHasher);
        }

        private static string CreateToken(User user, IPasswordHasher<User> passwordHasher)
            => passwordHasher.HashPassword(user, Guid.NewGuid().ToString("N")).Replace("=", string.Empty)
                .Replace("+", string.Empty).Replace("/", string.Empty);

    }
}
