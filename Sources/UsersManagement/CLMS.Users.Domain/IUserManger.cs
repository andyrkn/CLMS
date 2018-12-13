using CSharpFunctionalExtensions;

namespace CLMS.Users.Domain
{
    public interface IUserManger
    {
        Result Create(ApplicationUser user, string password);

        Result<ApplicationUser> CheckLogin(Email username, string password);
    }
}