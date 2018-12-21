using MediatR;

namespace CLMS.Courses.CrossCuttingConcerns
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}
