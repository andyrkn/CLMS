using MediatR;
using CLMS.Kernel;
using Microsoft.AspNetCore.Mvc;
using CLMS.QuestionsManagement.Business.Question.Models;
using CLMS.QuestionsManagement.Business.Question.Add;
using System.Collections.Generic;
using CLMS.QuestionsManagement.Business.Question.GetAll;
using CLMS.QuestionsManagement.Business.Question.Delete;
using System;
using CLMS.QuestionsManagement.Business.Answer.Add;
using CSharpFunctionalExtensions;

namespace CLMS.QuestionsManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : BaseApiController
    {
        public QuestionsController(IMediator mediator) : base(mediator) { }

        [HttpPost]
        public IActionResult CreateQuestion([FromBody] AddQuestionModel question)
        {
            var result = DispatchCommand(new AddNewQuestionCommand(question));
            return result.AsActionResult(Ok);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = DispatchQuery<GetAllQuestionsQuery, IEnumerable<QuestionModel>>(new GetAllQuestionsQuery());
            return Ok(result);
        }
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteQuestion([FromRoute]Guid id)
        {
            var result = DispatchCommand(new DeleteQuestionCommand(id));
            return result.AsActionResult(NoContent);
        }
        [HttpGet("{id:guid}")]
        public IActionResult GetQuestionById([FromRoute]Guid id)
        {
            var result = DispatchQuery<GetByQuestionIdQuery, Result<QuestionModel>>(new GetByQuestionIdQuery(id));
            return result.AsActionResult(Ok);
        }
    }
}