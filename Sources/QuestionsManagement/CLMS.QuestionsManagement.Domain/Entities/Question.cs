using System;
using CLMS.Kernel.Domain;
using System.Collections.Generic;
using System.Linq;
using CSharpFunctionalExtensions;

namespace CLMS.QuestionsManagement.Domain
{
    public class Question : Entity
    {
        private ICollection<Answer> answers = new List<Answer>();

        private Question(){}

        public string Name { get; private set; }

        public bool IsDeleted { get; private set; }

        public static Question Create(string name)
        {
            return new Question
            {
                Name = name,
                IsDeleted = false
            };
        }

        public IEnumerable<Answer> Answers
        {
            get => answers;
            private set => answers = value.ToList();
        }

        public void Answered(string answerText, string email)
        {
            var newAnswer = Answer.Create(answerText,email);
            answers.Add(newAnswer);
        }
        
        public Result ApproveAnswer(Guid answerId)
        {
            Maybe<Answer> answerOrNothing = answers.FirstOrDefault(x => x.Id == answerId);

            return answerOrNothing.ToResult("Answer not found!")
                .OnSuccess(answer => answer.Approve());
        }

    }
}