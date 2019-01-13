using System.Collections.Generic;

namespace CLMS.CoursesContentManagement.Business
{
    public class ContentHolderDetailsModel : ContentHolderModel
    {
        public IEnumerable<ContentModel> Contents { get; set; }
    }
}