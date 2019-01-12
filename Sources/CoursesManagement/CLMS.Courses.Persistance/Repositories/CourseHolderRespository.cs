using System.Linq;
using CLMS.Courses.Domain;
using CSharpFunctionalExtensions;

namespace CLMS.Courses.Persistance.Repositories
{
    public class CourseHolderRespository : Repository<CourseHolder>, ICourseHolderRespository
    {
        public CourseHolderRespository(CoursesContext context) : base(context)
        {
        }

        public Maybe<CourseHolder> GetByEmail(string email)
        {
            return DecoratedEntitiesSet(EntitiesSet).FirstOrDefault(x => x.Email == email);
        }
    }
}