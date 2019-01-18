using System;
using CLMS.Kernel;

namespace CLMS.Notification.Business
{
    public class UnsubscribeCommand : ICommand
    {
        public UnsubscribeCommand(Guid eventId, string email)
        {
            EventId = eventId;
            Email = email;
        }

        public Guid EventId { get; }
        public string Email { get; }
    }
}