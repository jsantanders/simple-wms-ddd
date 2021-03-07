using ProjectName.Domain.SharedKernel;

namespace ProjectName.Domain.Contracts
{
    public interface IDomainEventHandler<in T>
        where T : DomainEventBase
    {
        void Handle(T domainEvent);
    }
}
