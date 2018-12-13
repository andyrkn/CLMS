using System;
using System.Linq;

namespace CLMS.Users.Domain
{
    public interface IReadRepository<T> where T : Entity
    {
        IQueryable<T> GetAll ();
    }
}