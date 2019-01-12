using CSharpFunctionalExtensions;
using MediatR;

namespace CLMS.QuestionsManagement.Business.Question.Update
{
    public class UpdateQuestionCommandHandler : RequestHandler<UpdateQuestionCommand, Result>
    {
        protected override Result Handle(UpdateQuestionCommand request)
        {
            return Result.Ok();
        }
    }
}