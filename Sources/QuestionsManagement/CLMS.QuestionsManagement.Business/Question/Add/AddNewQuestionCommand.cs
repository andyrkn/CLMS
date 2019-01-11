using CLMS.QuestionsManagement.Business.Question.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLMS.QuestionsManagement.Business.Question.Add
{
    class AddNewQuestionCommand : ICommand
    {
        public QuestionModel QuestionModel { get; }

        public AddNewQuestionCommand(QuestionModel questionModel)
        {
            QuestionModel = questionModel;
        }
    }
}
