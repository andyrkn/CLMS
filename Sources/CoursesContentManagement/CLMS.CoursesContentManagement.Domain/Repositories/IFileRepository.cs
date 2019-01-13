using System;
using System.Collections.Generic;
using System.Linq;
using CLMS.Kernel.Domain;

namespace CLMS.CoursesContentManagement.Domain
{
    public interface IFileRepository : IWriteRepository<File>, IReadRepository<File>
    {
        IQueryable<File> FilesByIds(IEnumerable<Guid> id);
    }
}