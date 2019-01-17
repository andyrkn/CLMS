using CLMS.QuestionsManagement.Domain;
using CSharpFunctionalExtensions;
using EnsureThat;
using MediatR;

namespace CLMS.QuestionsManagement.Business.Question.Add
{
    internal class AddNewQuestionCommandHandler : RequestHandler<AddNewQuestionCommand, Result>
    {
        private readonly IQuestionsRepository questionsRepository;

        public AddNewQuestionCommandHandler(IQuestionsRepository questionsRepository)
        {
            EnsureArg.IsNotNull(questionsRepository);
            this.questionsRepository = questionsRepository;
        }

        protected override Result Handle(AddNewQuestionCommand request)
        {
            EnsureArg.IsNotNull(request);

            var question = Domain.Question.Create(request.QuestionModel.Name);
            questionsRepository.Add(question);
            questionsRepository.SaveChanges();

            return Result.Ok();
        }
    }
}