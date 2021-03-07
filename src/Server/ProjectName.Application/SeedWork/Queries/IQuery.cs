using MediatR;

namespace ProjectName.Application.SeedWork.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}
