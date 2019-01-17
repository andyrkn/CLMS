using System;
using System.Collections.Generic;
using System.Text;

namespace CLMS.QuestionsManagement.Business.Question.Models
{
    public class AnswerModel
    {
        public string AnswerText { get; set; }
        public string Email { get; set; }
        public Guid Id { get; set; }
        public bool IsApproved { get; set; }
    }
}
