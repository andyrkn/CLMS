using CLMS.Kernel.Domain;

namespace CLMS.Courses.Domain
{
    public class Course : Entity, IDeletable
    {
        private Course()
        {
        }

        public string Name { get; private set; }

        public CourseHolder Holder { get; private set; }

        public bool IsDeleted { get; private set; }

        public static Course Create(string name, CourseHolder holder)
        {
            return new Course
            {
                Name = name,
                Holder = holder,
                IsDeleted = false
            };
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
