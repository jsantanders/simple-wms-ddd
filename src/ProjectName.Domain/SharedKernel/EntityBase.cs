using System;
using System.Collections.Generic;
using ProjectName.Domain.Contracts;

namespace ProjectName.Domain.SharedKernel
{
    public abstract class EntityBase
    {
        private List<DomainEventBase> domainEvents;

        /// <summary>
        /// Domain events occurred.
        /// </summary>
        public IReadOnlyCollection<DomainEventBase> DomainEvents => domainEvents?.AsReadOnly();

        public void ClearDomainEvents()
        {
            domainEvents?.Clear();
        }

        /// <summary>
        /// Add domain event.
        /// </summary>
        /// <param name="domainEvent">Domain event.</param>
        protected void AddDomainEvent(DomainEventBase domainEvent)
        {
            domainEvents ??= new List<DomainEventBase>();

            this.domainEvents.Add(domainEvent);
        }

        protected void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken())
            {
                throw new BusinessRuleValidationException(rule);
            }
        }
    }
}
