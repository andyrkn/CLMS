using System.Collections.Generic;
using AutoMapper;
using CLMS.QuestionsManagement.Business.Question.Models;
using CLMS.QuestionsManagement.Domain;
using EnsureThat;
using MediatR;

namespace CLMS.QuestionsManagement.Business.Question.GetAll
{
    public class GetAllQuestionsQueryHandler : RequestHandler<GetAllQuestionsQuery, IEnumerable<QuestionModel>>
    {
        private readonly IMapper mapper;
        private readonly IQuestionsRepository questionsRepository;

        public GetAllQuestionsQueryHandler(IQuestionsRepository questionsRepository, IMapper mapper)
        {
            EnsureArg.IsNotNull(questionsRepository);
            EnsureArg.IsNotNull(mapper);
            this.questionsRepository = questionsRepository;
            this.mapper = mapper;
        }

        protected override IEnumerable<QuestionModel> Handle(GetAllQuestionsQuery request)
        {
            EnsureArg.IsNotNull(request);

            var questions = questionsRepository.GetAll();

            return mapper.Map<IEnumerable<QuestionModel>>(questions);
        }
    }
}