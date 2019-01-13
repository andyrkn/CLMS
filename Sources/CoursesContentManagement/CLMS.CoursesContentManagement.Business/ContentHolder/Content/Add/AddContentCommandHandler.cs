using AutoMapper;
using CLMS.CoursesContentManagement.Domain;
using CSharpFunctionalExtensions;
using EnsureThat;
using MediatR;

namespace CLMS.CoursesContentManagement.Business
{
    public class AddContentCommandHandler : RequestHandler<AddContentCommand, Result>
    {
        private readonly IFileRepository fileRepository;
        private readonly IContentHolderRepository contentHolderRepository;

        public AddContentCommandHandler(IFileRepository fileRepository, IContentHolderRepository contentHolderRepository)
        {
            EnsureArg.IsNotNull(fileRepository);
            this.fileRepository = fileRepository;
            this.contentHolderRepository = contentHolderRepository;
        }

        protected override Result Handle(AddContentCommand request)
        {
            EnsureArg.IsNotNull(request);
            var contentHodler = contentHolderRepository.GetById(request.ContentHolderId);

            var model = request.Model;
            var files = fileRepository.FilesByIds(model.FilesIds);
            var content = Content.Create(model.Description, files);

            return contentHodler.ToResult("Content holder not found!")
                .OnSuccess(x => x.AddContent(model.Email, content))
                .OnSuccess(() => contentHolderRepository.Update(contentHodler.Value))
                .OnSuccess(() => contentHolderRepository.SaveChanges());
        }
    }
}
