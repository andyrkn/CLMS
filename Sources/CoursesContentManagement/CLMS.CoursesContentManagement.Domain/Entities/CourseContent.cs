using System;
using System.Collections.Generic;
using System.Text;

namespace CLMS.CoursesContentManagement.Domain
{
    public class CourseContent : IDeletable
    {
        private CourseContent(){}

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public bool IsDeleted { get; private set; }
            
        public static CourseContent Create(string name)
        {
            return new CourseContent
            {
                Name = name,
                IsDeleted = false,
                Id = Guid.NewGuid()
            };
        }
    }
}
