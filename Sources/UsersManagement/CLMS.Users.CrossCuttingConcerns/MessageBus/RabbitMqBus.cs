using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace CLMS.Users.CrossCuttingConcerns
{
    public class RabbitMqBus : IMessageBus
    {
        private readonly IModel channel;
        private const string HostName = "localhost";
        private const string ExchangeType = "fanout";

        public RabbitMqBus()
        {
            var factory = new ConnectionFactory { HostName = HostName };
            var connection = factory.CreateConnection();
            channel = connection.CreateModel();
        }


        public Task Publish(string topicName, string message)
        {
            channel.ExchangeDeclare(topicName, ExchangeType);
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(topicName, string.Empty, null, body);

            return Task.CompletedTask;
        }
    }
}