﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSN.Common.Types;
using Microsoft.AspNetCore.Identity;
namespace DSN.Identity.Domain
{
    public class User: IIdentifiable
    {
        
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string Role { get; private set; }
        public string PasswordHash { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public User(Guid id, string email, string role)
        {
            Id = id;
            Email = email.ToLowerInvariant();
            Role = role;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
        public void SetPassword(string password, IPasswordHasher<User> passwordHasher)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new DSNException(Codes.InvalidPassword,$"Invalid password: '{Email}'.");
            }
            PasswordHash = passwordHasher.HashPassword(this, password);
        }

        public bool ValidatePassword(string password, IPasswordHasher<User> passwordHasher)
            => passwordHasher.VerifyHashedPassword(this, PasswordHash, password) != PasswordVerificationResult.Failed;
    }
    
}
