using System.Linq;
using System.Threading.Tasks;
using CLMS.Kernel;
using CLMS.Notification.Domain;
using CLMS.Notification.Domain.Entities;
using CLMS.Notification.Domain.Repository;
using CSharpFunctionalExtensions;
using EnsureThat;

namespace CLMS.Notification.Business
{
    public class ContentAddedEventHandler : IDomainEventHandler<ContentAddedEvent>
    {
        private readonly IEventRepository eventRepository;
        private readonly IEmailService emailService;

        public ContentAddedEventHandler(IEventRepository eventRepository, IEmailService emailService)
        {
            EnsureArg.IsNotNull(emailService);
            EnsureArg.IsNotNull(eventRepository);
            this.eventRepository = eventRepository;
            this.emailService = emailService;
        }

        public Task Handle(ContentAddedEvent @event)
        {
            EnsureArg.IsNotNull(@event);

            Maybe<Event> eventOrNothing = eventRepository.GetAll().FirstOrDefault(x => x.OriginId == @event.OriginId);

            eventOrNothing.ToResult("eventNotFound")
                .OnSuccess( ev => SendEmail(ev));

            return Task.CompletedTask;
        }

        private async Task SendEmail(Event ev)
        {
            var body = string.Format(EmailTemplates.ContentAdded, ev.Name);
            var emails =
                ev.Subscriptions.Select(x => EmailMessage.Create(x.Email, body, EmailTemplates.ContentAddedSubject));

            foreach (var emailMessage in emails)
            {
                await emailService.Send(emailMessage);
            }
        }
    }
}