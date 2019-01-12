using AutoMapper;

namespace CLMS.Courses.Business.Course
{
    public class CourseMappingProfile : Profile
    {
        public CourseMappingProfile()
        {
            CreateMap<Domain.Course, CourseModel>();
        }
    }
}