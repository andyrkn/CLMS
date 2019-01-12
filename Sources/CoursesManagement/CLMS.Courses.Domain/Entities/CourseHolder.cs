using CLMS.Kernel.Domain;

namespace CLMS.Courses.Domain
{
    public sealed class CourseHolder : Entity
    {
        private CourseHolder(string email)
        {
            Email = email;
        }

        public string Email { get; }

        public static CourseHolder Create(string email)
        {
            return new CourseHolder(email);
        }
    }
}