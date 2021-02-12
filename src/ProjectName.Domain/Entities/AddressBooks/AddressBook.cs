using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using ProjectName.Domain.Contracts;
using ProjectName.Domain.Entities.AddressBooks.Rules;
using ProjectName.Domain.SharedKernel;

namespace ProjectName.Domain.Entities.AddressBooks
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
            this.CheckRule(new ContactLabelCannotBeDuplicated(name, color));
            labels.Add(ContactLabel.Create(Id, name, color));
        }
    }
}