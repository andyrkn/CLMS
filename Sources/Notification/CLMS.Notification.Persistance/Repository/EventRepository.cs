using System.Linq;
using CLMS.Notification.Domain.Entities;
using CLMS.Notification.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace CLMS.Notification.Persistance.Repository
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(NotificationContext context) : base(context)
        {
        }

        public override IQueryable<Event> DecoratedEntitiesSet(IQueryable<Event> query)
        {
            return query.Include(x => x.Subscriptions);
        }
    }
}