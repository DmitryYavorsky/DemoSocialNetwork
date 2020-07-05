using DSN.Common.Messages;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSN.Identity.Messages.Events
{
    public class SignedUpEvent : INotification
    {
        public Guid UserId { get; }
        public string Email { get; }

        public SignedUpEvent() { }
        [JsonConstructor]
        public SignedUpEvent(Guid userId, string email)
        {
            UserId = userId == Guid.Empty ? Guid.NewGuid() : userId;
            Email = email;
        }
    }
}
