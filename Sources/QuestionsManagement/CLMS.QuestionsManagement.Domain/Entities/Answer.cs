using CLMS.Kernel.Domain;
namespace CLMS.QuestionsManagement.Domain
{
    public sealed class Answer : Entity
    {
        private Answer() { }

        public string AnswerText { get; private set; }
        public string Email { get; private set; }
        public bool IsApproved { get; private set; }
        public static Answer Create(string answerText, string email)
        {
            return new Answer
            {
                Email = email,
                AnswerText = answerText
            };
        }
        public void Approve()
        {
            IsApproved = true;
        }
            
    }
}
