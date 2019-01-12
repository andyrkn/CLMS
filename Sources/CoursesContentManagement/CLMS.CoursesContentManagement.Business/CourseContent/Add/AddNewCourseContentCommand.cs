using CLMS.Kernel;

namespace CLMS.CoursesContentManagement.Business
{
    public class AddNewCourseContentCommand : ICommand
    {
        public CourseContentModel CourseContentModel { get; }

        public AddNewCourseContentCommand(CourseContentModel courseModel)
        {
            CourseContentModel = courseModel;
        }
    }
}
