using System.Threading.Tasks;

namespace CLMS.Kernel
{
    public interface IDomainEventsDispatcher
    {
        Task Raise<T>(T @event)
            where T : class, IDomainEvent;
    }
}