using System;
using CLMS.Kernel;
using CLMS.Notification.Business;
using CLMS.Notification.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public IActionResult Subscribe([FromRoute] Guid id)
        {
            var result = DispatchCommand(new SubscribeCommand(id, User.GetUserEmail().Value));

            return result.AsActionResult(() => Created("api/events", new {id}));
        }

        [HttpDelete("{id:guid}/subscription")]
        [Authorize]
        public IActionResult Unsubscribe([FromRoute] Guid id)
        {
            var result = DispatchCommand(new UnsubscribeCommand(id, User.GetUserEmail().Value));

            return result.AsActionResult(NoContent);
        }
    }
}