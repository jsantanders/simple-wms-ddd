using ProjectName.Domain.SharedKernel;

namespace ProjectName.Domain.Entities.AddressBooks.Events
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
