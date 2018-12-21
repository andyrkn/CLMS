using System.Threading.Tasks;

namespace CLMS.Users.CrossCuttingConcerns
{
    public interface IDomainEventsDispatcher
    {
        Task Raise<T>(T @event)
            where T : class, IDomainEvent;
    }
}