using CSharpFunctionalExtensions;
using MediatR;

namespace CLMS.Kernel
{
    public interface ICommand : IRequest<Result>
    {
    }
}