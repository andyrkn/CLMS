using CLMS.Courses.Business;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CLMS.Kernel;
using Microsoft.AspNetCore.Authorization;

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
        public IActionResult CreateCourse([FromBody] AddCourseModel model)
        {
            var result = DispatchCommand(new CreateCourseCommand(model));
            return result.AsActionResult(Ok);
        }
    }
}
