using CSharpFunctionalExtensions;
using MediatR;
using EnsureThat;
using CLMS.QuestionsManagement.Domain;

namespace CLMS.QuestionsManagement.Business.Question.Delete
{
    public class DeleteQuestionCommandHandler : RequestHandler<DeleteQuestionCommand, Result>
    {
        private readonly IQuestionsRepository questionRepository;

        public DeleteQuestionCommandHandler(IQuestionsRepository questionRepository)
        {
            EnsureArg.IsNotNull(questionRepository);
            this.questionRepository = questionRepository;
        }

        protected override Result Handle(DeleteQuestionCommand request)
        {
            EnsureArg.IsNotNull(request);

            var questionOrNothing = questionRepository.GetById(request.QuestionId);

            return questionOrNothing.ToResult("Question not found")
                .OnSuccess(x => questionRepository.Delete(x))
                .OnSuccess( _ => questionRepository.SaveChanges());
           
        }


    }
}
