using CLMS.Kernel;

namespace CLMS.Users.Business
{
    public class RegisterUserCommand : ICommand
    {
        public UserModel Model { get; }

        public RegisterUserCommand(UserModel model)
        {
            Model = model;
        }
    }
}