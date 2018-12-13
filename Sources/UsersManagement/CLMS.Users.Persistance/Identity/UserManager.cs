using System.Linq;
using CLMS.Users.Domain;
using CSharpFunctionalExtensions;
using EnsureThat;
using Microsoft.AspNetCore.Identity;

namespace CLMS.Users.Persistance
{
    public class UserManager : IUserManger
    {
        private const string InvalidCredentials = "Invalid credentials";
        private readonly UserManager<ApplicationUser> identityManager;

        public UserManager(UserManager<ApplicationUser> identityManager)
        {
            EnsureArg.IsNotNull(identityManager);
            this.identityManager = identityManager;
        }

        public Result Create(ApplicationUser user, string password)
        {
            var createUserResult = identityManager.CreateAsync(user, password).Result;
            if (createUserResult.Succeeded)
            {
                return Result.Ok();
            }
            var error = createUserResult.Errors.First();

            return Result.Fail(error.Description);
        }

        public Result<ApplicationUser> CheckLogin(Email email, string password)
        {
            Maybe<ApplicationUser> user = identityManager.FindByEmailAsync(email).Result;
            return user.ToResult(InvalidCredentials)
                .Ensure(x => identityManager.CheckPasswordAsync(x, password).Result, InvalidCredentials);
        }
    }
}