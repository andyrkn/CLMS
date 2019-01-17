using AutoMapper;

namespace CLMS.QuestionsManagement.Business.Question.Models
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<Domain.Question, QuestionModel>();
            CreateMap<Domain.Answer, AnswerModel>();
        }
    }
}
