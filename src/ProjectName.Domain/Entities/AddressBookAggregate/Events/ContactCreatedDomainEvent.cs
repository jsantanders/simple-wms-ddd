using ProjectName.Domain.SharedKernel;

namespace ProjectName.Domain.Entities.AddressBookAggregate.Events
{
    public class ContactCreatedDomainEvent : DomainEventBase
    {
        public ContactCreatedDomainEvent(ContactId contactId)
        {
            ContactId = contactId;
        }

        public ContactId ContactId { get; }
    }
}
