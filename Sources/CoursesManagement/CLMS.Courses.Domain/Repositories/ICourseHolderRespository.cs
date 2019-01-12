using CLMS.Kernel.Domain;
using CSharpFunctionalExtensions;

namespace CLMS.Courses.Domain
{
    public interface ICourseHolderRespository : IWriteRepository<CourseHolder>, IReadRepository<CourseHolder>
    {
        Maybe<CourseHolder> GetByEmail(string email);
    }
}