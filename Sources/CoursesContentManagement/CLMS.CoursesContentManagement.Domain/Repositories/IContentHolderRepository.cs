using CLMS.Kernel.Domain;

namespace CLMS.CoursesContentManagement.Domain
{
    public interface IContentHolderRepository : IReadRepository<ContentHolder>, IWriteRepository<ContentHolder>
    {
    }
}