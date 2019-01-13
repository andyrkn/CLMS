using System.Linq;
using CLMS.CoursesContentManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace CLMS.CoursesContentManagement.Persistance
{
    public class ContentHolderRepository : Repository<ContentHolder>, IContentHolderRepository
    {
        public ContentHolderRepository(ContentContext context) : base(context)
        {
        }

        public override IQueryable<ContentHolder> DecoratedEntitiesSet(IQueryable<ContentHolder> query)
        {
            return query.Include(x => x.Contents)
                .ThenInclude(y => y.Files);
        }
    }
}