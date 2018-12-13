using MediatR;

namespace CLMS.Users.CrossCuttingConcerns
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}