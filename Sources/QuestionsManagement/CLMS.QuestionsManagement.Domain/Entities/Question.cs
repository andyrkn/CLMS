using System;
using CLMS.Kernel.Domain;
using System.Collections.Generic;
using CLMS.QuestionsManagement.Domain.Entities;
using System.Linq;

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

        public void Answered(string answerText)
        {
            var newAnswer = Answer.Create(answerText);
            answers.Add(newAnswer);
        }
    }
}