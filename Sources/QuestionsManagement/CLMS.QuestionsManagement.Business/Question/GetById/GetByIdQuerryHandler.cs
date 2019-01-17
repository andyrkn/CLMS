using System.Collections.Generic;
using AutoMapper;
using CLMS.QuestionsManagement.Business.Question.Models;
using CLMS.QuestionsManagement.Domain;
using CSharpFunctionalExtensions;
using EnsureThat;
using MediatR;

namespace CLMS.QuestionsManagement.Business.Question.GetAll
{
    public class GetByQuestionIdQueryHandler : RequestHandler<GetByQuestionIdQuery, Result<QuestionModel>>
    {
        private readonly IMapper mapper;
        private readonly IQuestionsRepository questionsRepository;

        public GetByQuestionIdQueryHandler(IQuestionsRepository questionsRepository, IMapper mapper)
        {
            EnsureArg.IsNotNull(questionsRepository);
            EnsureArg.IsNotNull(mapper);
            this.questionsRepository = questionsRepository;
            this.mapper = mapper;
        }

        protected override Result<QuestionModel> Handle(GetByQuestionIdQuery request)
        {
            EnsureArg.IsNotNull(request);

            var questionOrNothing = questionsRepository.GetById(request.Id);

            return questionOrNothing.ToResult("Question not found!")
                .Map(q => mapper.Map<QuestionModel>(q));
        }
    }
}