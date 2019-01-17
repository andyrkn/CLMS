using System;
using CLMS.Kernel;

namespace CLMS.QuestionsManagement.Business.Question.Delete
{
    public class DeleteQuestionCommand : ICommand
    {
        public Guid QuestionId { get; }
        public DeleteQuestionCommand(Guid questionId)
        {
            QuestionId = questionId;       
        }
    }
}
