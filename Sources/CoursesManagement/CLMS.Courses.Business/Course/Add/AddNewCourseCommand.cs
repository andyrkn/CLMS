using CLMS.Kernel;

namespace CLMS.Courses.Business
{
    public class AddNewCourseCommand : ICommand
    {
        public CourseModel CourseModel { get; }

        public AddNewCourseCommand(CourseModel courseModel)
        {
            CourseModel = courseModel;
        }
    }
}
