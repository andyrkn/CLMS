using CSharpFunctionalExtensions;
using MediatR;

namespace CLMS.Kernel
{
    public interface ICommand<T> : IRequest<Result<T>>
    {
    }
}