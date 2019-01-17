﻿using System;
using CLMS.Kernel;

namespace CLMS.Courses.Business
{
    public class CourseCreatedEvent : IDomainEvent
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string HolderEmail { get; set; }
    }
}