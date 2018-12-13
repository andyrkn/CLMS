using CSharpFunctionalExtensions;
using MediatR;

namespace CLMS.Users.CrossCuttingConcerns
{
    public interface ICommand : IRequest<Result>
    {
    }
}