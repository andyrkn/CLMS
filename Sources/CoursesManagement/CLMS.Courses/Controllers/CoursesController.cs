using CLMS.Courses.Business;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CLMS.Kernel;

namespace CLMS.Courses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : BaseApiController
    {
        public CoursesController(IMediator mediator):base(mediator) { }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = DispatchQuery<GetAllCoursesQuery, IEnumerable<CourseModel>>(new GetAllCoursesQuery());
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CourseModel model)
        {
            var result = DispatchCommand(new AddNewCourseCommand(model));
            return result.AsActionResult(Ok);
        }
    }
}
