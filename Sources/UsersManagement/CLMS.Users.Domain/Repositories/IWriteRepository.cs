using System;
using System.Linq;

namespace CLMS.Users.Domain
{
    public interface IWriteRepository<T> where T : Entity
    {
        void Add (T entity);
    }
}