using CLMS.CoursesContentManagement.Domain;

namespace CLMS.CoursesContentManagement.Persistance
{
    public class CoursesContentRepository : Repository<CourseContent>, ICoursesContentRepository
    {
        public CoursesContentRepository(CoursesContentContext context) : base(context)
        {

        }
    }
}
