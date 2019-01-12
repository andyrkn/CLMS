using System;

namespace CLMS.QuestionsManagement.Domain
{
    public class Question : IDeletable
    {
        private Question(){}

        public string Name { get; private set; }

        public Guid Id { get; private set; }

        public bool IsDeleted { get; private set; }

        public static Question Create(string name)
        {
            return new Question
            {
                Name = name,
                IsDeleted = false,
                Id = Guid.NewGuid()
            };
        }
        public void Delete()
        {
            IsDeleted = true;
        }
    }
}