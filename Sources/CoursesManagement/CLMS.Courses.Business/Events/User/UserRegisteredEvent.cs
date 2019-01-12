using CLMS.Kernel;

namespace CLMS.Courses.Business.Events
{
    public class UserRegisteredEvent : IDomainEvent
    {
        public string Email { get; set; }

        public string Role { get; set; }
    }
}