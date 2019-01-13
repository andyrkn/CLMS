using CLMS.CoursesContentManagement.Domain;
using CSharpFunctionalExtensions;
using EnsureThat;
using MediatR;

namespace CLMS.CoursesContentManagement.Business.File.Create
{
    public class CreateFileCommandHandler : RequestHandler<CreateFileCommand, Result>
    {
        private readonly IFileRepository fileRepository;

        public CreateFileCommandHandler(IFileRepository fileRepository)
        {
            EnsureArg.IsNotNull(fileRepository);
            this.fileRepository = fileRepository;
        }

        protected override Result Handle(CreateFileCommand request)
        {
            EnsureArg.IsNotNull(request);
            
            var fileContent = FileContent.crea

            return Result.Ok();
        }
    }
}