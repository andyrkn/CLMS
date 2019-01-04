using System.Threading.Tasks;

namespace CLMS.Kernel
{
    public interface IDomainEventHandler<in TEvent>
        where TEvent : class, IDomainEvent
    {
        Task Handle(TEvent @event);
    }
}