using System.Threading.Tasks;
using CLMS.Users.CrossCuttingConcerns;
using EnsureThat;

namespace CLMS.Users.Business
{
    // Just a proof of concept for event handling done in other microservices
    public class UserRegisteredEventHandler: IDomainEventHandler<UserRegisteredEvent>
    {
        public Task Handle(UserRegisteredEvent @event)
        {
            EnsureArg.IsNotNull(@event);
            var c = @event.Email;

            return Task.CompletedTask;
        }
    }
}