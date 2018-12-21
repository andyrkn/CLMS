using CLMS.Courses.CrossCuttingConcerns;

namespace CLMS.Courses.Business
{
    public class AddNewCourseCommand : ICommand<CourseModel>
    {
        public CourseModel courseModel;
        public AddNewCourseCommand(CourseModel courseModel)
        {
            this.courseModel = courseModel;
        }
    }
}
