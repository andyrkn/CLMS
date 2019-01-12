﻿using CLMS.QuestionsManagement.Business.Question.Models;
using CLMS.Kernel;

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
