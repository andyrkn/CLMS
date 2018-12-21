using System;
using System.Text;
using System.Threading.Tasks;
using EnsureThat;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CLMS.Users.CrossCuttingConcerns
{
    public class RabbitMqBusListener : IMessageBusListener
    {
        private const string HostName = "localhost";
        private const string ExchangeType = "fanout";
        private const string EventSuffix = "Event";
        private const string TopicSuffix = "Topic";
        private readonly IModel channel;
        private readonly IDependencyScope dependencyScope;

        public RabbitMqBusListener(IDependencyScope dependencyScope)
        {
            EnsureArg.IsNotNull(dependencyScope);
            this.dependencyScope = dependencyScope;
            var factory = new ConnectionFactory {HostName = HostName};
            var connection = factory.CreateConnection();
            channel = connection.CreateModel();
        }

        public void ListenTo<TDomainEvent>()
            where TDomainEvent : class, IDomainEvent
        {
            var handler = dependencyScope.Resolve<IDomainEventHandler<TDomainEvent>>();
            ListenTo(typeof(TDomainEvent), handler.GetType());
        }

        public void ListenTo(Type eventType, Type eventHandlerType)
        {
            var topic = TopicNameFromEventName(eventType.Name);

            channel.ExchangeDeclare(topic, ExchangeType);
            var queueName = channel.QueueDeclare().QueueName;
            channel.QueueBind(queueName, topic, string.Empty);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                var deserialized = JsonConvert.DeserializeObject(message, eventType);
                var handler = dependencyScope.Resolve(eventHandlerType);
                Task.Run(() =>
                    handler.GetType().GetMethod(nameof(IDomainEventHandler<IDomainEvent>.Handle))
                        .Invoke(handler, new[] {deserialized}));
            };

            channel.BasicConsume(queueName, true, consumer);
        }

        private static string TopicNameFromEventName(string eventName) =>
            eventName.EndsWith(EventSuffix) ? eventName.Replace(EventSuffix, TopicSuffix) : $"{eventName}{TopicSuffix}";
    }
}