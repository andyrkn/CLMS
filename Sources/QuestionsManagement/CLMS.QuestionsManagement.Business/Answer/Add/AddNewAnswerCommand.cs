using System;
using CLMS.Kernel;
using CLMS.QuestionsManagement.Business.Question.Models;

namespace CLMS.QuestionsManagement.Business.Answer.Add
{
    public class AddNewAnswerCommand : ICommand
    {
        public AddNewAnswerCommand(Guid questionId, string email, AddAnswerModel model)
        {
            QuestionId = questionId;
            Email = email;
            Model = model;
        }

        public Guid QuestionId { get; }
        public string Email { get; }
        public AddAnswerModel Model { get; }
    }
}
