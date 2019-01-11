using AutoMapper;
using CLMS.QuestionsManagement.Business.Question.Models;
using CLMS.QuestionsManagement.Domain;
using EnsureThat;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLMS.QuestionsManagement.Business.Question.GetAll
{
    class GetAllQuestionsQuery : IQuery<IEnumerable<QuestionModel>>
    {
        private readonly IQuestionsRepository questionsRepository;
        private readonly IMapper mapper;

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
