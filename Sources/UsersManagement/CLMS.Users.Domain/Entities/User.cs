using System;

namespace CLMS.Users.Domain
{
    public class User : Entity
    {

        private User () { }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Priviledge { get; private set; }

        public User Create (string firstName, string lastName, string email, string priviledge)
        {
            return new User
            {
                FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Priviledge = priviledge
            };
        }

    }
}