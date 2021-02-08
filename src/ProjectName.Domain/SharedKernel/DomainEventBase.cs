using System;

namespace ProjectName.Domain.SharedKernel
{
    public abstract class DomainEventBase
    {
        public DomainEventBase()
        {
            OccuredOn = DateTime.UtcNow;
        }

        public DateTime OccuredOn { get; protected set; }
    }
}
