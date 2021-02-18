using System;
using System.Collections.Generic;
using ProjectName.Domain.Contracts;

namespace ProjectName.Domain.SharedKernel
{
    public abstract class EntityBase<TKey>
        where TKey : StronglyTypedIdBase
    {
        private List<DomainEventBase> events;

        /// <summary>
        /// Domain events occurred.
        /// </summary>
        public IReadOnlyCollection<DomainEventBase> Events => events?.AsReadOnly();

        public TKey Id { get; protected set; }

        public void ClearDomainEvents()
        {
            events?.Clear();
        }

        /// <summary>
        /// Add domain event.
        /// </summary>
        /// <param name="domainEvent">Domain event.</param>
        protected void AddDomainEvent(DomainEventBase domainEvent)
        {
            events ??= new List<DomainEventBase>();

            this.events.Add(domainEvent);
        }

        public void ClearEvents()
        {
            events.Clear();
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
