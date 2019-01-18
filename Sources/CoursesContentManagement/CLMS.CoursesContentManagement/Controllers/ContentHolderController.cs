using System;
using System.Collections.Generic;
using CLMS.CoursesContentManagement.Business;
using CLMS.CoursesContentManagement.Extensions;
using CLMS.Kernel;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CLMS.CoursesContentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentHolderController : BaseApiController
    {
        public ContentHolderController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetContentHolders()
        {
            var result = DispatchQuery<GetAllContentHoldersQuery, IReadOnlyCollection<ContentHolderModel>>(new GetAllContentHoldersQuery());

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetContentHolder([FromRoute]Guid id)
        {
            var result =
                DispatchQuery<GetContentHolderQuery, Result<ContentHolderDetailsModel>>(
                    new GetContentHolderQuery(id));

            return result.AsActionResult(Ok);
        }

        [HttpPost("{id:guid}/content")]
        [Authorize(Roles = "Teacher")]
        public IActionResult Add([FromRoute] Guid id, [FromBody] AddContentModel model)
        {
            var result = DispatchCommand(new AddContentCommand(model, User.GetUserEmail().Value, id));
            return result.AsActionResult(() => Created("api/content", model));
        }
    }
}