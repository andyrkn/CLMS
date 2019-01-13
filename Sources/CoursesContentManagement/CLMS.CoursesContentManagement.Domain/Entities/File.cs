using System;
using CLMS.Kernel.Domain;

namespace CLMS.CoursesContentManagement.Domain
{
    public sealed class File : Entity
    {
        private File()
        {
        }

        public string Name { get; private set; }

        public string Extension { get; private set; }

        public FileContent Content { get; private set; }

        public Guid FileContentId { get; private set; }

        public static File Create(string name, string extenstion, FileContent content)
        {
            return new File
            {
                Name = name,
                Extension = extenstion,
                Content = content,
                FileContentId = content.Id
            };
        }
    }
}