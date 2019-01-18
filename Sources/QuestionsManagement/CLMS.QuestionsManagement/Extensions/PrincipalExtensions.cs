using System.Security.Claims;
using System.Security.Principal;
using CSharpFunctionalExtensions;

namespace CLMS.Questions.Extensions
{
    public static class PrincipalExtensions
    {
        public static Maybe<string> GetUserEmail(this IPrincipal principal)
        {
            var claimIdentity = (ClaimsIdentity)principal.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.Email);
            return claim?.Value;
        }
    }
}