using CLMS.QuestionsManagement.Business.Question.Models;
using CLMS.Kernel;
using System;
using CSharpFunctionalExtensions;

namespace CLMS.QuestionsManagement.Business.Question.GetAll
{
    public class GetByQuestionIdQuery : IQuery<Result<QuestionModel>>
    {
        public Guid Id {get; }
        public GetByQuestionIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
