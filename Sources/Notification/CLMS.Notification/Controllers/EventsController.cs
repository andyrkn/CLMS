using System;
using CLMS.Kernel;
using CLMS.Notification.Business;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CLMS.Notification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : BaseApiController
    {
        public EventsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("{id:guid}/subscription")]
        public IActionResult Subscribe([FromRoute] Guid id, [FromBody] SubscribeModel model)
        {
            var result = DispatchCommand(new SubscribeCommand(id, model));

            return result.AsActionResult(() => Created("api/events", new {id}));
        }

        [HttpDelete("{id:guid}/subscription")]
        public IActionResult Unsubscribe([FromRoute] Guid id, [FromBody] UnsubscribeModel model)
        {
            var result = DispatchCommand(new UnsubscribeCommand(id, model));

            return result.AsActionResult(() => Created("api/events", new {id}));
        }
    }
}