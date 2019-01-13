using System;
using System.Collections.Generic;
using System.Linq;
using CLMS.CoursesContentManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace CLMS.CoursesContentManagement.Persistance
{
    public class FileRepository : Repository<File>, IFileRepository
    {
        public FileRepository(ContentContext context) : base(context)
        {
        }

        public IQueryable<File> FilesByIds(IEnumerable<Guid> ids)
        {
            return EntitiesSet.Where(x => ids.Contains(x.Id));
        }

        public override IQueryable<File> DecoratedEntitiesSet(IQueryable<File> query)
        {
            return query.Include(x => x.Content);
        }
    }
}