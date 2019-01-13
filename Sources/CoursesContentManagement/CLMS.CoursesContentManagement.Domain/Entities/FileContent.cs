using CLMS.Kernel.Domain;

namespace CLMS.CoursesContentManagement.Domain
{
    public class FileContent : Entity
    {
        private FileContent()
        {
        }

        public byte[] Bytes { get; private set; }

        public static FileContent Create(byte[] bytes)
        {
            return new FileContent
            {
                Bytes = bytes
            };
        }
    }
}