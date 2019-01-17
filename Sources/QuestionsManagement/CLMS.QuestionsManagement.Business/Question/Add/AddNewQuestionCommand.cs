using CLMS.QuestionsManagement.Business.Question.Models;
using CLMS.Kernel;

namespace CLMS.QuestionsManagement.Business.Question.Add
{
    public class AddNewQuestionCommand : ICommand
    {
        public AddQuestionModel QuestionModel { get; }

        public AddNewQuestionCommand(AddQuestionModel questionModel)
        {
            QuestionModel = questionModel;
        }
    }
}
