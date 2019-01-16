using CLMS.Kernel.Domain;
namespace CLMS.QuestionsManagement.Domain.Entities
{
    public sealed class Answer : Entity
    {
        public string AnswerText { get; private set; }

        public static Answer Create(string answerText)
        {
            return new Answer
            {
                AnswerText = answerText
            };
        }
            
    }
}
