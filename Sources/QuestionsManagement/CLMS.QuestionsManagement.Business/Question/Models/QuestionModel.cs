using System;
using System.Collections.Generic;

namespace CLMS.QuestionsManagement.Business.Question.Models
{
    public class QuestionModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<AnswerModel> Answers;
    }
}