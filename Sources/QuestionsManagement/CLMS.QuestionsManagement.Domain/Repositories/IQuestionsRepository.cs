namespace CLMS.QuestionsManagement.Domain
{
    public interface IQuestionsRepository : IWriteRepository<Question>, IReadRepository<Question>
    {

    }
}
