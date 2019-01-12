using System;
using System.Linq;
using CSharpFunctionalExtensions;

namespace CLMS.Kernel.Domain
{
    public interface IReadRepository<T>
        where T : Entity
    {
        Maybe<T> GetById(Guid id);

        IQueryable<T> GetAll();
    }
}