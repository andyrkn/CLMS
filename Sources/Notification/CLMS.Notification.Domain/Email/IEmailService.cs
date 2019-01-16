using System.Threading.Tasks;

namespace CLMS.Notification.Domain
{
    public interface IEmailService
    {
        Task Send(EmailMessage message);
    }
}