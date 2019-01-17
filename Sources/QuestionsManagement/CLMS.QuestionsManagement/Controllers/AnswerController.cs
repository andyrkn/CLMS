﻿using System;
using CLMS.Kernel;
using CLMS.QuestionsManagement.Business.Answer.Add;
using CLMS.QuestionsManagement.Business.Question.ApproveAnswer;
using CLMS.QuestionsManagement.Business.Question.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CLMS.QuestionsManagement.Controllers
{
    [Route("api/questions/{questionId:guid}/[controller]")]
    [ApiController]
    public class AnswerController : BaseApiController
    {
        public AnswerController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        public IActionResult AddAnswer([FromRoute] Guid id, [FromBody] AddAnswerModel model)
        {
            var result = DispatchCommand(new AddNewAnswerCommand(id, model));

            return result.AsActionResult(() => Created("api/questions/answers", new { id }));
        }
        [HttpPut("{id:guid}")]
        public IActionResult ApproveAnswer([FromRoute] Guid id, [FromRoute] Guid questionId)
        {
            var result = DispatchCommand(new ApproveAnswerCommand(questionId,id));

            return result.AsActionResult(NoContent);
        }
    }
}