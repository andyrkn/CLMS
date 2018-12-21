using AutoMapper;
using CLMS.Courses.Domain;
using EnsureThat;
using MediatR;
using System.Collections.Generic;

namespace CLMS.Courses.Business
{
    public class GetAllCoursesQueryHandler : RequestHandler<GetAllCoursesQuery, IEnumerable<CourseModel>>
    {
        private readonly ICoursesRepository coursesRepository;
        private readonly IMapper mapper;

        public GetAllCoursesQueryHandler(ICoursesRepository coursesRepository, IMapper mapper)
        {
            EnsureArg.IsNotNull(coursesRepository);
            EnsureArg.IsNotNull(mapper);
            this.coursesRepository = coursesRepository;
            this.mapper = mapper;
        }

        protected override IEnumerable<CourseModel> Handle(GetAllCoursesQuery request)
        {
            EnsureArg.IsNotNull(request);

            var courses = coursesRepository.GetAll();

            return mapper.Map<IEnumerable<CourseModel>>(courses);
        }
    }
}
