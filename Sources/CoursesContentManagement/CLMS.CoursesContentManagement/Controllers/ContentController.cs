using CLMS.CoursesContentManagement.Business;
using CLMS.Kernel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
    }
}