using CLMS.Kernel;

namespace CLMS.CoursesContentManagement.Business.Events.ContentHolder
{
    internal class CourseCreatedEvent : IDomainEvent
    {
        public string Name { get; set; }

        public string HolderEmail { get; set; }
    }
}