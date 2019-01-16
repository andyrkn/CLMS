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

namespace CLMS.QuestionsManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : BaseApiController
    {
        public QuestionsController(IMediator mediator) : base(mediator) { }

        [HttpPost]
        public IActionResult CreateQuestion([FromBody] QuestionModel question)
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
        [HttpPost("{id:guid}/answer")]
        public IActionResult AddAnswer([FromRoute] Guid id, [FromBody] AnswerModel model)
        {
            var result = DispatchCommand(new AddNewAnswerCommand(id, model));

            return result.AsActionResult(() => Created("api/events", new { id }));
        }

    }
}