using CLMS.Courses.Domain;
using CLMS.Kernel;
using CSharpFunctionalExtensions;
using EnsureThat;
using MediatR;

namespace CLMS.Courses.Business
{
    public class CreateCourseCommandHandler : RequestHandler<CreateCourseCommand, Result>
    {
        private readonly ICoursesRepository coursesRepository;
        private readonly ICourseHolderRespository courseHolderRespository;
        private readonly IDomainEventsDispatcher eventsDispatcher;

        public CreateCourseCommandHandler(ICoursesRepository coursesRepository, ICourseHolderRespository courseHolderRespository, IDomainEventsDispatcher eventsDispatcher)
        {
            EnsureArg.IsNotNull(coursesRepository);
            this.coursesRepository = coursesRepository;
            this.courseHolderRespository = courseHolderRespository;
            this.eventsDispatcher = eventsDispatcher;
        }

        protected override Result Handle(CreateCourseCommand request)
        {
            EnsureArg.IsNotNull(request);
            var holder = courseHolderRespository.GetByEmail(request.CourseModel.HolderEmail);

            return holder.ToResult("Course holder not found")
                .OnSuccess(x => CreateCourse(request.CourseModel.Name, holder.Value));

        }

        private Result CreateCourse(string name, CourseHolder holder)
        {
            var course = Domain.Course.Create(name, holder);
            coursesRepository.Add(course);
            coursesRepository.SaveChanges();
            eventsDispatcher.Raise(new CourseCreatedEvent {Name = name, HolderEmail = holder.Email});

            return Result.Ok();
        }
    }
}
