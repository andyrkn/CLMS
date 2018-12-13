using System;

namespace CLMS.Users.Domain
{
    public interface IUserRepository : IReadRepository<User>, IWriteRepository<User>
    {

    }
}