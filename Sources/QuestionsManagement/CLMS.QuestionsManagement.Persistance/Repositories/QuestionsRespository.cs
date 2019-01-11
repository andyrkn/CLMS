using CLMS.QuestionsManagement.Domain;

namespace CLMS.QuestionsManagement.Persistance.Repositories
{
    public class QuestionsRepository : Repository<Question>, IQuestionsRepository
    {
        public QuestionsRepository(QuestionsContext context) : base(context)
        {

        }
    }
}
