using MediatR;
using CLMS.Kernel;
using Microsoft.AspNetCore.Mvc;

namespace CLMS.QuestionsManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : BaseApiController
    {
        public QuestionsController(IMediator mediator) : base(mediator) { }
    }
}
