using System.Threading.Tasks;
using EnsureThat;
using Newtonsoft.Json;

namespace CLMS.Users.CrossCuttingConcerns
{
    public class DomainEventsDipatcher : IDomainEventsDispatcher
    {
        private const string EventSuffix = "Event";
        private const string TopicSuffix = "Topic";
        private readonly IMessageBus messageBus;

        public DomainEventsDipatcher(IMessageBus messageBus)
        {
            EnsureArg.IsNotNull(messageBus);
            this.messageBus = messageBus;
        }

        public Task Raise<T>(T @event) 
            where T : class, IDomainEvent
        {
            EnsureArg.IsNotNull(@event);
            var eventName = typeof(T).Name;
            var topicName = TopicNameFromEventName(eventName);

            var serializedEvent = JsonConvert.SerializeObject(@event);
            messageBus.Publish(topicName, serializedEvent);

            return Task.CompletedTask;
        }

        private static string TopicNameFromEventName(string eventName) =>
            eventName.EndsWith(EventSuffix) ? eventName.Replace(EventSuffix, TopicSuffix) : $"{eventName}{TopicSuffix}";
    }
}