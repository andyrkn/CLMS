﻿using CLMS.Kernel;

namespace CLMS.Courses.Business
{
    internal class CourseCreatedEvent : IDomainEvent
    {
        public string Name { get; set; }

        public string HolderEmail { get; set; }
    }
}