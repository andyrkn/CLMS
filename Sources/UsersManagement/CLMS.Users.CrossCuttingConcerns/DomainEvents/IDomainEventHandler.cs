using System.Threading.Tasks;

namespace CLMS.Users.CrossCuttingConcerns
{
    public interface IDomainEventHandler<in TEvent>
        where TEvent : class, IDomainEvent
    {
        Task Handle(TEvent @event);
    }
}