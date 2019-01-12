using CLMS.CoursesContentManagement.Business;
using CLMS.Kernel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CLMS.CoursesContentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesContentController : BaseApiController
    {
        public CoursesContentController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public IActionResult Add([FromBody] CourseContentModel model)
        {
            var result = DispatchCommand(new AddNewCourseContentCommand(model));
            return result.AsActionResult(Ok);
        }
    }
}