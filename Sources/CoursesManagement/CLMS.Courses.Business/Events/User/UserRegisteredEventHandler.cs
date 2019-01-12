using System.Threading.Tasks;
using CLMS.Courses.Domain;
using CLMS.Kernel;
using EnsureThat;

namespace CLMS.Courses.Business.Events
{
    public class UserRegisteredEventHandler : IDomainEventHandler<UserRegisteredEvent>
    {
        private const string TeacherRole = "Teacher";
        private readonly ICourseHolderRespository courseHolderRespository;

        public UserRegisteredEventHandler(ICourseHolderRespository courseHolderRespository)
        {
            this.courseHolderRespository = courseHolderRespository;
        }

        public Task Handle(UserRegisteredEvent @event)
        {
            EnsureArg.IsNotNull(@event);

            if (@event.Role == TeacherRole)
            {
                var holder = CourseHolder.Create(@event.Email);
                courseHolderRespository.Add(holder);
                courseHolderRespository.SaveChanges();
            }

            return Task.CompletedTask;
        }
    }
}