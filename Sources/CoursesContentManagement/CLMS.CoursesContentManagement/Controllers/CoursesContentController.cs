using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using CLMS.CoursesContentManagement.Business;

namespace CLMS.CoursesContentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesContentController : BaseApiController
    {
        public CoursesContentController(IMediator mediator) : base(mediator) { }

        [HttpPost]
        public IActionResult Add([FromBody] CourseContentModel model)
        {
            var result = DispatchCommand(new AddNewCourseContentCommand(model));
            return result.AsActionResult(Ok);
        }
    }
}