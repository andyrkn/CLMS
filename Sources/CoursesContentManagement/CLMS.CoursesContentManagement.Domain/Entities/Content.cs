using System.Collections.Generic;
using System.Linq;
using CLMS.Kernel.Domain;

namespace CLMS.CoursesContentManagement.Domain
{
    public class Content : Entity, IDeletable
    {
        private ICollection<File> files = new List<File>();

        private Content()
        {
        }

        public string Description { get; private set; }

        public IEnumerable<File> Files
        {
            get => files.ToList();
            private set => files = value.ToList();
        }

        public bool IsDeleted { get; private set; }

        public static Content Create(string description, IEnumerable<File> files)
        {
            return new Content
            {
                Description = description,
                files = files.ToList()
            };
        }
    }
}