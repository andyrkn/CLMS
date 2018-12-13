using System;
using CLMS.Users.Domain;

namespace CLMS.Users.Persistance
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository (UsersContext context) : base (context)
        {

        }
    }

}