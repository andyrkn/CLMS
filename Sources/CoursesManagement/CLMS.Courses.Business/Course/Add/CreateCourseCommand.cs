using CLMS.Kernel;

namespace CLMS.Courses.Business
{
    public class CreateCourseCommand : ICommand
    {
        public AddCourseModel CourseModel { get; }

        public CreateCourseCommand(AddCourseModel courseModel)
        {
            CourseModel = courseModel;
        }
    }
}
