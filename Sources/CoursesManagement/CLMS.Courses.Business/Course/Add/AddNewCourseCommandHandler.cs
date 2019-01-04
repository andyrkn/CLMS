using AutoMapper;
using CLMS.Courses.Domain;
using CSharpFunctionalExtensions;
using EnsureThat;
using MediatR;

namespace CLMS.Courses.Business
{
    public class AddNewCourseCommandHandler : RequestHandler<AddNewCourseCommand, Result>
    {
        private readonly ICoursesRepository coursesRepository;

        public AddNewCourseCommandHandler(ICoursesRepository coursesRepository)
        {
            EnsureArg.IsNotNull(coursesRepository);
            this.coursesRepository = coursesRepository;
        }

        protected override Result Handle(AddNewCourseCommand request)
        {
            EnsureArg.IsNotNull(request);

            var course = Course.Create(request.CourseModel.Name, request.CourseModel.Holder);

            coursesRepository.Add(course);
            coursesRepository.Save();

            return Result.Ok();
        }
    }
}
