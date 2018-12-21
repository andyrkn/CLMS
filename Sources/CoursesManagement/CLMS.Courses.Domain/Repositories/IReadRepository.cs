using System;
using System.Linq;
using CSharpFunctionalExtensions;

namespace CLMS.Courses.Domain
{
    public interface IReadRepository<T>
        where T : Course
    {
        Maybe<T> GetById(Guid id);

        IQueryable<T> GetAll();
    }
}
