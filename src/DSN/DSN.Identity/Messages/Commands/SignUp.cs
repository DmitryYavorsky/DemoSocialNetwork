using System;
using Newtonsoft.Json;

namespace DSN.Identity.Messages.Commands
{
    public class SignUp
    {
        public Guid Id { get; }
        public string Email { get; }
        public string Password { get; }
        public string Role { get; }

        
        [JsonConstructor]
        public SignUp(Guid id, string email, string password, string role)
        {
            Id = Guid.Empty != id? id: Guid.NewGuid();
            Email = email;
            Password = password;
            Role = role;
        }
    }
}
