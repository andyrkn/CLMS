using CLMS.Users.CrossCuttingConcerns;

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