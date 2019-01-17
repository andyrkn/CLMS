using CLMS.QuestionsManagement.Domain;
using CSharpFunctionalExtensions;
using EnsureThat;
using MediatR;

namespace CLMS.QuestionsManagement.Business.Answer.Add
{
    public class AddNewAnswerCommandHandler : RequestHandler<AddNewAnswerCommand, Result>
    {
        private readonly IQuestionsRepository questionRepository;

        public AddNewAnswerCommandHandler(IQuestionsRepository questionRepository)
        {
            EnsureArg.IsNotNull(questionRepository);
            this.questionRepository = questionRepository;
        }

        protected override Result Handle(AddNewAnswerCommand request)
        {
            EnsureArg.IsNotNull(request);

            var questionOrNothing = questionRepository.GetById(request.QuestionId);

            return questionOrNothing.ToResult("Event not found")
                .OnSuccess(q => q.Answered(request.Model.AnswerText, request.Model.Email))
                .OnSuccess(_ => questionRepository.Update(questionOrNothing.Value))
                .OnSuccess(_ => questionRepository.SaveChanges());
        }

    }
}