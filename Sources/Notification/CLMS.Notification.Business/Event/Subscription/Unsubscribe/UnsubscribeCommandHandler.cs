using CLMS.Notification.Domain.Repository;
using CSharpFunctionalExtensions;
using EnsureThat;
using MediatR;
using System.Linq;

namespace CLMS.Notification.Business
{
    public class UnsubscribeCommandHandler : RequestHandler<UnsubscribeCommand, Result>
    {
        private readonly IEventRepository eventRepository;

        public UnsubscribeCommandHandler(IEventRepository eventRepository)
        {
            EnsureArg.IsNotNull(eventRepository);
            this.eventRepository = eventRepository;
        }

        protected override Result Handle(UnsubscribeCommand request)
        {
            EnsureArg.IsNotNull(request);

            Maybe<Domain.Entities.Event> eventOrNothing = eventRepository.GetAll().FirstOrDefault(x => x.OriginId == request.EventId);

            return eventOrNothing.ToResult("Event not found")
                .OnSuccess(ev => ev.Unsubscribe(request.Email))
                .OnSuccess(() => eventRepository.Update(eventOrNothing.Value))
                .OnSuccess(() => eventRepository.SaveChanges());
        }
    }
}