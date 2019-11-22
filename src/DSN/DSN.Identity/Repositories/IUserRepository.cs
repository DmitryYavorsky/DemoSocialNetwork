using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSN.Identity.Domain;

namespace DSN.Identity.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
    }
}
