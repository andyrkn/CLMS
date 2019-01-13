using System.IO;
using System.Linq;
using CLMS.CoursesContentManagement.Business;
using CLMS.CoursesContentManagement.Business.File.Create;
using CLMS.Kernel;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CLMS.CoursesContentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : BaseApiController
    {
        public FileController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("{name}")]
        public IActionResult GetFile(string name)
        {
            var result = DispatchQuery<GetFileQuery, Result<FileModel>>(new GetFileQuery(name));
            if (result.IsSuccess)
            {
                return File(result.Value.Bytes, "application/octet-stream");
            }

            return new BadRequestObjectResult(result.Error);
        }

        [HttpPost]
        public IActionResult CreateFile([FromForm] IFormFile file)
        {
            byte[] fileConntentAsBytes;

            using (var stream = file.OpenReadStream())
            {
                var memoryStream = stream as MemoryStream;

                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    stream.CopyTo(memoryStream);
                }

                fileConntentAsBytes = memoryStream.ToArray();
            }

            var result = DispatchCommand<CreateFileCommand, string>(new CreateFileCommand(file.FileName,
                file.FileName.Split('.').Last(), fileConntentAsBytes));
            return result.AsActionResult(filename => Created($"api/file/{filename}", new {fileName = filename}));
        }
    }
}