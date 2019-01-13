using CLMS.Kernel;

namespace CLMS.CoursesContentManagement.Business
{
    public class AddContentCommand : ICommand
    {
        public AddContentModel Model { get; }

        public AddContentCommand(AddContentModel addModel)
        {
            Model = addModel;
        }
    }
}
