using AutoMapper;
using CLMS.CoursesContentManagement.Domain;
using CSharpFunctionalExtensions;
using EnsureThat;
using MediatR;

namespace CLMS.CoursesContentManagement.Business
{
    public class AddNewCourseContentCommandHandler : RequestHandler<AddNewCourseContentCommand, Result>
    {
        private readonly ICoursesContentRepository coursesContentRepository;

        public AddNewCourseContentCommandHandler(ICoursesContentRepository coursesContentRepository)
        {
            EnsureArg.IsNotNull(coursesContentRepository);
            this.coursesContentRepository = coursesContentRepository;
        }

        protected override Result Handle(AddNewCourseContentCommand request)
        {
            EnsureArg.IsNotNull(request);

            var courseContent = CourseContent.Create(request.CourseContentModel.Name);

            coursesContentRepository.Add(courseContent);
            coursesContentRepository.Save();

            return Result.Ok();
        }
    }
}
