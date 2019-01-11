using CSharpFunctionalExtensions;
using EnsureThat;
using CLMS.QuestionsManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLMS.QuestionsManagement.Business.Question.Add
{
    class AddNewQuestionCommandHandler : RequestHandler <AddNewQuestionCommand, Result>
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

            var question = Question.Create(request.QuestionModel.Name);
            
            questionsRepository.Add(question);
            questionsRepository.Save();

            return Result.Ok();
        }

    }
}
