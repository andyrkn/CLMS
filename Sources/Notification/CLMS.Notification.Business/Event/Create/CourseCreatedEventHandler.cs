using System.Threading.Tasks;
using CLMS.Kernel;
using CLMS.Notification.Domain.Entities;
using CLMS.Notification.Domain.Repository;
using EnsureThat;

namespace CLMS.Notification.Business
{
    public class CourseCreatedEventHandler : IDomainEventHandler<CourseCreatedEvent>
    {
        private readonly IEventRepository eventRepository;

        public CourseCreatedEventHandler(IEventRepository eventRepository)
        {
            EnsureArg.IsNotNull(eventRepository);
            this.eventRepository = eventRepository;
        }

        public Task Handle(CourseCreatedEvent courseCreatedEvent)
        {
            EnsureArg.IsNotNull(courseCreatedEvent);

            var @event = Event.Create(courseCreatedEvent.Id, courseCreatedEvent.Name);
            eventRepository.Add(@event);
            eventRepository.SaveChanges();

            return Task.CompletedTask;
        }
    }
}