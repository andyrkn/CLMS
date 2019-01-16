using System;
using CLMS.Kernel;

namespace CLMS.Notification.Business
{
    public class UnsubscribeCommand : ICommand
    {
        public UnsubscribeCommand(Guid eventId, UnsubscribeModel model)
        {
            EventId = eventId;
            Model = model;
        }

        public Guid EventId { get; }
        public UnsubscribeModel Model { get; }
    }
}