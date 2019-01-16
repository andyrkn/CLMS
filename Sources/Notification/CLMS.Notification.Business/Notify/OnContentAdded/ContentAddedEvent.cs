using System;
using CLMS.Kernel;

namespace CLMS.Notification.Business
{
    public class ContentAddedEvent : IDomainEvent
    {
        public Guid OriginId { get; set; }
    }
}