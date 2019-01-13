using CLMS.CoursesContentManagement.Business;
using CLMS.Kernel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CLMS.CoursesContentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : BaseApiController
    {
        public ContentController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public IActionResult Add([FromBody] AddContentModel model)
        {
            var result = DispatchCommand(new AddContentCommand(model));
            return result.AsActionResult(() => Created("api/content", model));
        }
    }
}