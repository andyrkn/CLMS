using System;
using CLMS.Kernel;

namespace CLMS.CoursesContentManagement.Business
{
    public class AddContentCommand : ICommand
    {
        public AddContentCommand(AddContentModel addModel, string email, Guid contentHolderId)
        {
            Model = addModel;
            Email = email;
            ContentHolderId = contentHolderId;
        }

        public AddContentModel Model { get; }
        public string Email { get; }
        public Guid ContentHolderId { get; }
    }
}