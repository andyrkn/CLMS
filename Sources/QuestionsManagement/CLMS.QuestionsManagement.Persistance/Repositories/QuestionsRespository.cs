using CLMS.QuestionsManagement.Domain;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CLMS.QuestionsManagement.Persistance.Repositories
{
    public class QuestionsRepository : Repository<Question>, IQuestionsRepository
    {
        public QuestionsRepository(QuestionsContext context) : base(context)
        {

        }


        public override IQueryable<Question> DecoratedEntitiesSet(IQueryable<Question> query)
        {
            return query.Include(x => x.Answers);
        }
    }
}
