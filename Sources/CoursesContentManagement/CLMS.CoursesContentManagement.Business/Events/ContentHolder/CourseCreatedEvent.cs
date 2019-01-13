﻿using CLMS.Kernel;

namespace CLMS.CoursesContentManagement.Business
{
    public class CourseCreatedEvent : IDomainEvent
    {
        public string Name { get; set; }

        public string HolderEmail { get; set; }
    }
}