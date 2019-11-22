using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSN.Common.Mongo;
using DSN.Identity.Domain;

namespace DSN.Identity.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly IMongoRepository<User> _repository;
        public UserRepository(IMongoRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<User> GetAsync(Guid id)
            => await _repository.GetAsync(id);

        public async Task<User> GetAsync(string email)
            => await _repository.GetAsync(x => x.Email == email.ToLowerInvariant());

        public async Task AddAsync(User user)
            => await _repository.AddAsync(user);

        public async Task UpdateAsync(User user)
            => throw new NotImplementedException();
    }
}
