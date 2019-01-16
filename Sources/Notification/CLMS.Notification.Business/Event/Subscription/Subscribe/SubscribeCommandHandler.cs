using CLMS.Notification.Domain.Repository;
using CSharpFunctionalExtensions;
using EnsureThat;
using MediatR;

namespace CLMS.Notification.Business
{
    public class SubscribeCommandHandler : RequestHandler<SubscribeCommand, Result>
    {
        private readonly IEventRepository eventRepository;

        public SubscribeCommandHandler(IEventRepository eventRepository)
        {
            EnsureArg.IsNotNull(eventRepository);
            this.eventRepository = eventRepository;
        }

        protected override Result Handle(SubscribeCommand request)
        {
            EnsureArg.IsNotNull(request);

            var eventOrNothing = eventRepository.GetById(request.EventId);

            return eventOrNothing.ToResult("Event not found")
                .OnSuccess(ev => ev.Subscribe(request.Model.Email))
                .OnSuccess(_ => eventRepository.Update(eventOrNothing.Value))
                .OnSuccess(_ => eventRepository.SaveChanges());
        }
    }
}