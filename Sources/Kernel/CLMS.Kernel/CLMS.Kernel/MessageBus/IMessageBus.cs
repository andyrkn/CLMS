using System.Threading.Tasks;

namespace CLMS.Kernel
{
    public interface IMessageBus
    {
        Task Publish(string topicName, string message);
    }
}