using CLMS.Kernel.Domain;

namespace CLMS.Courses.Domain
{
    public interface ICoursesRepository : IWriteRepository<Course>, IReadRepository<Course>
    {
    }
}
