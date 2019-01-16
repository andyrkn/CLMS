using System;
using CLMS.Kernel;

namespace CLMS.Notification.Business
{
    public class CourseCreatedEvent : IDomainEvent
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

    }
}