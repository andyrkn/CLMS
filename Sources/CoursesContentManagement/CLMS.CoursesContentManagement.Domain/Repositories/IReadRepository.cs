using System;
using System.Linq;
using CSharpFunctionalExtensions;

namespace CLMS.CoursesContentManagement.Domain
{
    public interface IReadRepository<T>
        where T : CourseContent
    {
        Maybe<T> GetById(Guid id);

        IQueryable<T> GetAll();
    }
}
