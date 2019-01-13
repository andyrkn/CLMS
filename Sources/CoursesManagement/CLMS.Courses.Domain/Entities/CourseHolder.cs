using CLMS.Kernel.Domain;

namespace CLMS.Courses.Domain
{
    public sealed class CourseHolder : Entity
    {
        private CourseHolder()
        {
        }

        private CourseHolder(string email)
        {
            Email = email;
        }

        public string Email { get; private set; }

        public static CourseHolder Create(string email)
        {
            return new CourseHolder(email);
        }
    }
}