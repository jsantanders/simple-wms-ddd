using MediatR;

namespace ProjectName.Application.Common
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}
