using System;
using System.Linq;
using CLMS.CoursesContentManagement.Domain;
using CSharpFunctionalExtensions;
using EnsureThat;
using MediatR;

namespace CLMS.CoursesContentManagement.Business
{
    public class GetFileQueryHandler : RequestHandler<GetFileQuery, Result<FileModel>>
    {
        private readonly IFileRepository fileRepository;

        public GetFileQueryHandler(IFileRepository fileRepository)
        {
            EnsureArg.IsNotNull(fileRepository);
            this.fileRepository = fileRepository;
        }

        protected override Result<FileModel> Handle(GetFileQuery request)
        {
            EnsureArg.IsNotNull(request);

            Maybe<string> id = request.FileName.Split('.').FirstOrDefault();
            Maybe<string> extension = request.FileName.Split('.').LastOrDefault();

            var idResult = id.ToResult("Invalid id");
            var extensionResult = extension.ToResult("Invalid extension");

            return Result.Combine(idResult, extensionResult).OnSuccess(() =>
            {
                Maybe<Domain.File> file = fileRepository.GetAll()
                    .FirstOrDefault(x => x.Id == new Guid(id.Value) && x.Extension == extension.Value);
                return file.ToResult("File not found")
                    .Map(x => new FileModel {Bytes = file.Value.Content.Bytes});
            });
        }
    }
}