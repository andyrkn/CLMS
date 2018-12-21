using System.Threading.Tasks;

namespace CLMS.Users.CrossCuttingConcerns
{
    public interface IMessageBus
    {
        Task Publish(string topicName, string message);
    }
}