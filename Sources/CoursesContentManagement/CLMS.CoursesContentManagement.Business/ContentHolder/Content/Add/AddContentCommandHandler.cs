using CLMS.CoursesContentManagement.Business.Events;
using CLMS.CoursesContentManagement.Domain;
using CLMS.Kernel;
using CSharpFunctionalExtensions;
using EnsureThat;
using MediatR;

namespace CLMS.CoursesContentManagement.Business
{
    public class AddContentCommandHandler : RequestHandler<AddContentCommand, Result>
    {
        private readonly IContentHolderRepository contentHolderRepository;
        private readonly IDomainEventsDispatcher eventsDispatcher;
        private readonly IFileRepository fileRepository;

        public AddContentCommandHandler(IFileRepository fileRepository,
            IContentHolderRepository contentHolderRepository, IDomainEventsDispatcher
                eventsDispatcher)
        {
            EnsureArg.IsNotNull(contentHolderRepository);
            EnsureArg.IsNotNull(eventsDispatcher);
            EnsureArg.IsNotNull(fileRepository);
            this.fileRepository = fileRepository;
            this.contentHolderRepository = contentHolderRepository;
            this.eventsDispatcher = eventsDispatcher;
        }

        protected override Result Handle(AddContentCommand request)
        {
            EnsureArg.IsNotNull(request);
            var contentHolder = contentHolderRepository.GetById(request.ContentHolderId);

            var model = request.Model;
            var files = fileRepository.FilesByIds(model.FilesIds);
            var content = Content.Create(model.Description, files);

            return contentHolder.ToResult("Content holder not found!")
                .OnSuccess(x => x.AddContent(request.Email, content))
                .OnSuccess(() => contentHolderRepository.Update(contentHolder.Value))
                .OnSuccess(() => contentHolderRepository.SaveChanges())
                .OnSuccess(() => eventsDispatcher.Raise(new ContentAddedEvent
                {
                    ContentHolderName = contentHolder.Value.Name,
                    OriginId = contentHolder.Value.OriginId
                }));
        }
    }
}