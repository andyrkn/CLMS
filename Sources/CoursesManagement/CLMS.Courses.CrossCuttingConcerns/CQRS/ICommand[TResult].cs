using CSharpFunctionalExtensions;
using MediatR;

namespace CLMS.Courses.CrossCuttingConcerns
{
    public interface ICommand<out TResult> : IRequest<TResult>
        where TResult : class
    {

    }
}
