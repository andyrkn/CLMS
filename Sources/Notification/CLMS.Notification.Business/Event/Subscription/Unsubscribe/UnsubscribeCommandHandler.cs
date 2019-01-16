using CLMS.Notification.Domain.Repository;
using CSharpFunctionalExtensions;
using EnsureThat;
using MediatR;

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

            var eventOrNothing = eventRepository.GetById(request.EventId);

            return eventOrNothing.ToResult("Event not found")
                .OnSuccess(ev => ev.Unsubscribe(request.Model.Email));
        }
    }
}