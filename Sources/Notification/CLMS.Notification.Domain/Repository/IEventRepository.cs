using CLMS.Kernel.Domain;
using CLMS.Notification.Domain.Entities;

namespace CLMS.Notification.Domain.Repository
{
    public interface IEventRepository : IWriteRepository<Event>, IReadRepository<Event>
    {
    }
}