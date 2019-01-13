using CLMS.Kernel;

namespace CLMS.CoursesContentManagement.Business.File.Create
{
    public class CreateFileCommand : ICommand<string>
    {
        public CreateFileCommand(string name, string extensions, byte[] content)
        {
            Name = name;
            Extensions = extensions;
            Content = content;
        }

        public string Name { get; }
        public string Extensions { get; }
        public byte[] Content { get; }
    }
}