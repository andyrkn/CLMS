using System;
using CLMS.Kernel;
using CLMS.QuestionsManagement.Business.Question.Models;

namespace CLMS.QuestionsManagement.Business.Answer.Add
{
    public class AddNewAnswerCommand : ICommand
    {
        public AddNewAnswerCommand(Guid questionId, AnswerModel model)
        {
            QuestionId = questionId;
            Model = model;
        }

        public Guid QuestionId { get; }
        public AnswerModel Model { get; }
    }
}
