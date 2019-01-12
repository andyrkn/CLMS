using System.Linq;
using CLMS.Courses.Domain;
using Microsoft.EntityFrameworkCore;

namespace CLMS.Courses.Persistance.Repositories
{
    public class CoursesRepository : Repository<Course>, ICoursesRepository
    {
        public CoursesRepository(CoursesContext context) : base(context)
        {
        }

        public override IQueryable<Course> DecoratedEntitiesSet(IQueryable<Course> query)
        {
            return query.Include(x => x.Holder);
        }
    }
}
