using CLMS.CoursesContentManagement.Domain;
using CSharpFunctionalExtensions;
using EnsureThat;
using MediatR;

namespace CLMS.CoursesContentManagement.Business.File.Create
{
    public class CreateFileCommandHandler : RequestHandler<CreateFileCommand, Result<string>>
    {
        private readonly IFileRepository fileRepository;

        public CreateFileCommandHandler(IFileRepository fileRepository)
        {
            EnsureArg.IsNotNull(fileRepository);
            this.fileRepository = fileRepository;
        }

        protected override Result<string> Handle(CreateFileCommand request)
        {
            EnsureArg.IsNotNull(request);

            var fileContent = FileContent.Create(request.Content);
            var file = Domain.File.Create(request.Name, request.Extensions, fileContent);

            fileRepository.Add(file);
            fileRepository.SaveChanges();

            return Result.Ok<string>($"{file.Id}.{file.Extension}");
        }
    }
}