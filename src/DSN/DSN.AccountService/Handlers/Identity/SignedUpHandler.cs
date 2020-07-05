using System.Threading;
using System.Threading.Tasks;
using DSN.AccountService.Messages.Events;
using DSN.AccountService.Repositories.Interfaces;
using MediatR;

namespace DSN.AccountService.Handlers.Identity
{
    public class SignedUpHandler : INotificationHandler<SignedUp>
    {

        private readonly IAccountsRepository _repo;
        public SignedUpHandler(IAccountsRepository repo)
        {
            _repo = repo;
        }
        public async Task Handle(SignedUp notification, CancellationToken cancellationToken)
        {
            await _repo.AddAsync(new Domain.Account(notification.UserId, notification.Email));
        }
    }
}
