using System;

namespace CLMS.Courses.Domain
{
    public class Course : IDeletable
    {
        private Course() { }
    
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Holder { get; private set; }

        public bool IsDeleted { get; private set; }

        public static Course Create(string name,string holder)
        {
            return new Course
            {
                Name = name,
                Holder = holder,
                IsDeleted = false,
                Id = Guid.NewGuid()
            };
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
