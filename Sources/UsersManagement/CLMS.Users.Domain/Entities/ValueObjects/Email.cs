using System.Collections.Generic;
using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace CLMS.Users.Domain
{
    public class Email : ValueObject
    {
        private Email()
        {
        }

        public string Value { get; private set; }

        public static Result<Email> Create(string value)
        {
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var match = regex.Match(value);
            if (!match.Success)
            {
                return Result.Fail<Email>(ErrorMessages.InvalidEmail);
            }

            var email = new Email
            {
                Value = value
            };

            return Result.Ok(email);
        }

        public static implicit operator string(Email email)
        {
            return email.Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}