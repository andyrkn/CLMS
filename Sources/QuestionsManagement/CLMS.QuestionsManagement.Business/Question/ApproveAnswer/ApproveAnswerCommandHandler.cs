using CLMS.QuestionsManagement.Domain;
using CSharpFunctionalExtensions;
using EnsureThat;
using MediatR;

namespace CLMS.QuestionsManagement.Business.Question.ApproveAnswer
{
    public class ApproveAnswerCommandHandler : RequestHandler<ApproveAnswerCommand, Result>
    {
        private readonly IQuestionsRepository questionsRepository;

        public ApproveAnswerCommandHandler(IQuestionsRepository questionsRepository)
        {
            EnsureArg.IsNotNull(questionsRepository);
            this.questionsRepository = questionsRepository;
        }

        protected override Result Handle(ApproveAnswerCommand request)
        {
            EnsureArg.IsNotNull(request);
            var questionOrNothing = questionsRepository.GetById(request.QuestionId);

            return questionOrNothing.ToResult("Question Not found")
                .OnSuccess(question => question.ApproveAnswer(request.AnswerId))
                .OnSuccess(() => questionsRepository.Update(questionOrNothing.Value))
                .OnSuccess(() => questionsRepository.SaveChanges());
        }
    }
}
