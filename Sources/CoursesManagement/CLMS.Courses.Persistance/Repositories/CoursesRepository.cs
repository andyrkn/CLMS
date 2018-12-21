using CLMS.Courses.Domain;

namespace CLMS.Courses.Persistance.Repositories
{
    public class CoursesRepository : Repository<Course>, ICoursesRepository
    {
        public CoursesRepository(CoursesContext context) : base(context)
        {

        }
    }
}
