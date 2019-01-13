using CLMS.CoursesContentManagement.Domain;

namespace CLMS.CoursesContentManagement.Persistance
{
    public class ContentHolderRepository : Repository<ContentHolder>, IContentHolderRepository
    {
        public ContentHolderRepository(ContentContext context) : base(context)
        {
        }
    }
}