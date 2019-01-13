using System;
using System.Collections.Generic;

namespace CLMS.CoursesContentManagement.Business
{
    public class AddContentModel
    {
        public string Email { get; set; }

        public Guid ContentHolderId { get; set; }

        public string Description { get; set; }

        public IEnumerable<Guid> FilesIds { get; set; }
    }
}
