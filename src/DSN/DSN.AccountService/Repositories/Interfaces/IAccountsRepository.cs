using DSN.AccountService.Domain;
using System;
using System.Threading.Tasks;

namespace DSN.AccountService.Repositories.Interfaces
{
    public interface IAccountsRepository
    {
        Task AddAsync(Account account);
        Task<Account> GetAsync(Guid id);
    }
}
