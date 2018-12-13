using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace CLMS.Users.Domain
{
    public class Name : ValueObject
    {
        public string Value { get; private set; }

        private Name()
        {
        }

        public static Result<Name> Create(Maybe<string> nameOrNothing)
        {
            return nameOrNothing.ToResult(ErrorMessages.InvalidName)
                .Ensure(x => !string.IsNullOrEmpty(x), ErrorMessages.InvalidName)
                .Map(x => new Name {Value = x});
        }

        public static implicit operator string(Name name)
        {
            return name.Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}