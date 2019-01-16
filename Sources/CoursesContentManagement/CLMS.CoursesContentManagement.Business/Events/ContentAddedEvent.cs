using System;
using CLMS.Kernel;

namespace CLMS.CoursesContentManagement.Business.Events
{
    public class ContentAddedEvent : IDomainEvent
    {
        public Guid OriginId { get; set; }

        public string ContentHolderName { get; set; }
    }
}