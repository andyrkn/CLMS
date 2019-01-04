using CLMS.Kernel;

namespace CLMS.Users.Business
{
    public class UserRegisteredEvent : IDomainEvent
    {
        public string Email { get; set; }

        public string Role { get; set; }
    }
}