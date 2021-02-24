using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using ProjectName.Domain.Contracts;
using ProjectName.Domain.Entities.AddressBooks.Rules;
using ProjectName.Domain.Entities.Users;
using ProjectName.Domain.SharedKernel;

namespace ProjectName.Domain.Entities.AddressBooks
{
    public class AddressBook : EntityBase<AddressBookId>, IAggregateRoot
    {
        private List<Contact> contacts;
        private List<ContactLabel> labels;

        private AddressBook()
        {
        }

        private AddressBook(UserId userId)
        {
            Id = new AddressBookId(Guid.NewGuid());
            contacts = new List<Contact>();
            labels = new List<ContactLabel>();
            UserId = Guard.Against.Null(userId, nameof(userId));
        }

        public UserId UserId { get; private set; }

        public IReadOnlyCollection<Contact> Contacts => contacts.AsReadOnly();

        public IReadOnlyCollection<ContactLabel> Labels => labels.AsReadOnly();

        public ContactId AddContact(
            ContactName contactName,
            ContactCompany contactCompany,
            DateTime? birthday,
            string notes,
            Address address,
            List<Telephone> telephones,
            List<Email> emails)
        {
            var contact = Contact.Create(Id, contactName, contactCompany, birthday, notes, address, telephones, emails);
            contacts.Add(contact);

            return contact.Id;
        }

        public void UpdateContactInfo(
            ContactId contactId,
            ContactName name,
            ContactCompany company,
            DateTime? birthday,
            string notes)
        {
            var contact = contacts.Single(c => c.Id == contactId);
            contact.UpdateContactInfo(name, company, birthday, notes);
        }

        public void AddLabel(string name, string color)
        {
            this.CheckRule(new ContactLabelCannotBeDuplicatedRule(name, color));
            labels.Add(ContactLabel.Create(Id, name, color));
        }

        public void RemoveContact(ContactId contactId)
        {
            var contact = contacts.SingleOrDefault(c => c.ContactId == contactId);
            contacts.Remove(contact);
        }

        public void RemoveLabel(ContactLabelId labelId)
        {
            var label = labels.SingleOrDefault(l => l.ContactLabelId == labelId);
            labels.Remove(label);
        }

        public static AddressBook Create(UserId userId)
        {
            return new AddressBook(userId);
        }
    }
}
