using System.Collections.Generic;

namespace CLMS.CoursesContentManagement.Business
{
    public class ContentModel
    {
        public string Description { get; set; }

        public IEnumerable<FileModel> Files { get; set; }
    }
}