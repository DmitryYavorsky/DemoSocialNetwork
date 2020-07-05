using DSN.Common.Messages;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSN.AccountService.Messages.Events
{
    [MessageNamespace("identity")]
    public class SignedUp : INotification
    {
        public Guid UserId { get; }
        public string Email { get; }

        public SignedUp() { }
        [JsonConstructor]
        public SignedUp(Guid userId, string email)
        {
            UserId = userId == Guid.Empty ? Guid.NewGuid() : userId;
            Email = email;
        }
    }
}
