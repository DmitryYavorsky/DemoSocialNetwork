using System;
using System.Threading.Tasks;
using DSN.AccountService.Domain;
using DSN.AccountService.Repositories.Interfaces;
using DSN.Common.Mongo;

namespace DSN.AccountService.Repositories.Implementations
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly IMongoRepository<Account> _repository;
        public AccountsRepository(IMongoRepository<Account> repository)
        {
            _repository = repository;
        }
        public async Task AddAsync(Account account)
            => await _repository.AddAsync(account);

        public async Task<Account> GetAsync(Guid id)
            => await _repository.GetAsync(id);
    }
}
