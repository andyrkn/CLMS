using System.Threading.Tasks;
using CLMS.Users.CrossCuttingConcerns;
using CLMS.Users.Domain;
using CSharpFunctionalExtensions;
using EnsureThat;
using MediatR;

namespace CLMS.Users.Business
{
    public class RegisterUserCommandHandler : RequestHandler<RegisterUserCommand, Result>
    {
        private readonly IUserManger userManger;
        private readonly IDomainEventsDispatcher domainEventsDispatcher;

        public RegisterUserCommandHandler(IUserManger userManger, IDomainEventsDispatcher domainEventsDispatcher)
        {
            EnsureArg.IsNotNull(domainEventsDispatcher);
            EnsureArg.IsNotNull(userManger);
            this.userManger = userManger;
            this.domainEventsDispatcher = domainEventsDispatcher;
        }

        protected override Result Handle(RegisterUserCommand command)
        {
            EnsureArg.IsNotNull(command);
            var firstNameResult = Name.Create(command.Model.FirstName);
            var lastNameResult = Name.Create(command.Model.LastName);
            var emailNameResult = Email.Create(command.Model.Email);

            return Result.Combine(firstNameResult, lastNameResult, emailNameResult)
                .Map(() => ApplicationUser.Create(firstNameResult.Value, lastNameResult.Value,
                    emailNameResult.Value, command.Model.Role))
                .OnSuccess(x => userManger.Create(x, command.Model.Password))
                .OnSuccess(() => RaiseUserRegisteredEvent(emailNameResult.Value, command.Model.Role));
        }

        private Task RaiseUserRegisteredEvent(Email email, Role userRole)
        {
            return domainEventsDispatcher.Raise(new UserRegisteredEvent
            {
                Email = email.Value,
                Role = userRole.ToString("G")
            });
        }
    }
}