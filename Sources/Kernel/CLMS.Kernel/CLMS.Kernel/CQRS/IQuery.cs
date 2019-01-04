using MediatR;

namespace CLMS.Kernel
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}