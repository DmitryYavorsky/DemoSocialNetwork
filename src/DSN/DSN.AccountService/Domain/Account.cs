using DSN.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSN.AccountService.Domain
{
    public class Account : IIdentifiable
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public List<Account> Friends { get; private set; }
        

        protected Account()
        {

        }

        public Account(Guid id, string email)
        {
            Id = id;
            Email = email;
            CreatedAt = DateTime.UtcNow;
        }
        public Account(Guid id, string name, string lastName, string email)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Email = email;
            CreatedAt = DateTime.UtcNow;
        }


    }
}
