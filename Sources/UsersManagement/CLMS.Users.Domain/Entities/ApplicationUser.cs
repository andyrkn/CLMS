using System;
using Microsoft.AspNetCore.Identity;

namespace CLMS.Users.Domain
{
    public class ApplicationUser : IdentityUser<Guid>, IDeletable
    {
        private ApplicationUser()
        {
        }

        public Name FirstName { get; private set; }

        public Name LastName { get; private set; }

        public Role Role { get; private set; }

        public bool IsDeleted { get; private set; }

        public static ApplicationUser Create(Name firstName, Name lastName, Email email, Role role)
        {
            return new ApplicationUser
            {
                UserName = email,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Role = role
            };
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}