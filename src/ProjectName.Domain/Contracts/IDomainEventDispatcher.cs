using ProjectName.Domain.SharedKernel;

namespace ProjectName.Domain.Contracts
{
    public interface IDomainEventDispatcher
    {
        void Dispatch(DomainEventBase @event);
    }
}
