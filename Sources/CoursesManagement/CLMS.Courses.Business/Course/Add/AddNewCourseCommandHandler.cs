using AutoMapper;
using CLMS.Courses.Domain;
using CSharpFunctionalExtensions;
using EnsureThat;
using MediatR;

namespace CLMS.Courses.Business
{
    public class AddNewCourseCommandHandler : RequestHandler<AddNewCourseCommand,CourseModel>
    {
        private readonly ICoursesRepository coursesRepository;
        private readonly IMapper mapper;

        public AddNewCourseCommandHandler(ICoursesRepository coursesRepository,IMapper mapper)
        {
            EnsureArg.IsNotNull(coursesRepository);
            EnsureArg.IsNotNull(mapper);
            this.coursesRepository = coursesRepository;
            this.mapper = mapper;
        }

        protected override CourseModel Handle(AddNewCourseCommand request)
        {
            EnsureArg.IsNotNull(request);

            var course = Course.Create(request.courseModel.Name, request.courseModel.Holder);

            coursesRepository.Add(course);
            coursesRepository.Save();

            return mapper.Map<CourseModel>(course);
        }
    }
}
