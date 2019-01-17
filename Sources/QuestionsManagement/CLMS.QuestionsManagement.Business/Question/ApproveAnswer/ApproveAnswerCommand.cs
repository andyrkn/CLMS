using System;
using CLMS.Kernel;

namespace CLMS.QuestionsManagement.Business.Question.ApproveAnswer
{
    public class ApproveAnswerCommand : ICommand
    {
        public Guid QuestionId { get; }
        public Guid AnswerId { get; }
        public ApproveAnswerCommand(Guid questionId, Guid answerId)
        {
            QuestionId = questionId;
            AnswerId = answerId;
        }
    }
}
