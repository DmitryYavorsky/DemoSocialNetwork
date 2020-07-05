using DSN.Common.Messages;
using MediatR;
using Newtonsoft.Json;
using System;

namespace DSN.ApiGetWay.Messages.Commands.Accounts
{
    [MessageNamespace("accounts")]
    public class CreateAccount : IRequest
    {
        public Guid Id { get; }
        public string Name { get; }
        public string LastName { get; }
        public string Email { get; }
        public CreateAccount() { }
        [JsonConstructor]
        public CreateAccount(Guid id, string name, string lastName, string email)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            Name = name;
            LastName = lastName;
            Email = email;
        }
    }
}
