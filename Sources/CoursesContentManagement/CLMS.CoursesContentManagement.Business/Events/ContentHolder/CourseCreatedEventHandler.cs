using System.Threading.Tasks;
using CLMS.CoursesContentManagement.Domain;
using CLMS.Kernel;
using EnsureThat;

namespace CLMS.CoursesContentManagement.Business.Events.ContentHolder
{
    public class CourseCreatedEventHandler : IDomainEventHandler<CourseCreatedEvent>
    {
        private readonly IContentHolderRepository contentHolderRepository;

        public CourseCreatedEventHandler(IContentHolderRepository contentHolderRepository)
        {
            EnsureArg.IsNotNull(contentHolderRepository);
            this.contentHolderRepository = contentHolderRepository;
        }

        public Task Handle(CourseCreatedEvent @event)
        {
            EnsureArg.IsNotNull(@event);
            var contentHolder = Domain.ContentHolder.Create(@event.Name, @event.HolderEmail);

            contentHolderRepository.Add(contentHolder);
            contentHolderRepository.SaveChanges();

            return Task.CompletedTask;
        }
    }
}