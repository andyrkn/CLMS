using CLMS.Kernel;
using CSharpFunctionalExtensions;

namespace CLMS.CoursesContentManagement.Business
{
    public class GetFileQuery : IQuery<Result<FileModel>>
    {
        public GetFileQuery(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; }
    }
}