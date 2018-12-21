using CSharpFunctionalExtensions;
using MediatR;

namespace CLMS.Courses.CrossCuttingConcerns
{
    public interface ICommand : IRequest<Result>
    {

    }
}
