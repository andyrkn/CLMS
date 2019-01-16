using System;
using CLMS.Kernel;

namespace CLMS.Notification.Business
{
    public class SubscribeCommand : ICommand
    {
        public SubscribeCommand(Guid eventId, SubscribeModel model)
        {
            EventId = eventId;
            Model = model;
        }

        public Guid EventId { get; }
        public SubscribeModel Model { get; }
    }
}