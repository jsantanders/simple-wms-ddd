using System;
using System.Collections.Generic;
using System.Linq;
using ProjectName.Domain.Contracts;
using ProjectName.Domain.SharedKernel;

namespace ProjectName.Domain.Entities.AddressBookAggregate
{
    public class AddressBook : EntityBase<AddressBookId>, IAggregateRoot
    {
        private List<Contact> contacts;
        private List<ContactLabel> labels;

        private AddressBook()
        {
            Id = new AddressBookId(Guid.NewGuid());
        }

        public IReadOnlyCollection<Contact> Contacts => contacts.AsReadOnly();

        public IReadOnlyCollection<ContactLabel> Labels => labels.AsReadOnly();

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        public void AddLabel(string name, string color)
        {
            this.CheckRule(new ContactLabelConnotBeDuplicated(name, color));
            labels.Add(ContactLabel.Create(Id, name, color));
        }
    }
}
