using CLMS.Kernel;
using Microsoft.AspNetCore.Mvc;
using CLMS.Users.Business;
using MediatR;

namespace CLMS.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseApiController
    {
        public UsersController(IMediator mediator) 
            : base(mediator)
        {
        }

        [HttpPost]
        public IActionResult Register([FromBody] UserModel user)
        {
            var result = DispatchCommand(new RegisterUserCommand(user));
            return result.AsActionResult(Ok);
        }
    }
}
