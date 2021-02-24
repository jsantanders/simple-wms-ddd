using System;
using System.Collections.Generic;
using Ardalis.GuardClauses;
using ProjectName.Domain.Entities.AddressBooks.Events;
using ProjectName.Domain.Entities.AddressBooks.Rules;
using ProjectName.Domain.SharedKernel;

namespace ProjectName.Domain.Entities.AddressBooks
{
    public class Contact : EntityBase<ContactId>
    {
        private List<Telephone> telephones;
        private List<Email> emails;

        private Contact()
        {
        }

        private Contact(
            AddressBookId addressBookId,
            ContactName name,
            ContactCompany company,
            DateTime? birthday,
            string notes,
            Address address,
            List<Telephone> telephones,
            List<Email> emails)
        {
            AddressBookId = addressBookId;
            ContactId = new ContactId(Guid.NewGuid());
            Name = Guard.Against.Null(name, nameof(name));
            Company = company;
            Birthday = birthday;
            Notes = notes;
            Address = address;
            this.telephones = telephones ?? new List<Telephone>();
            this.emails = emails ?? new List<Email>();

            this.AddDomainEvent(new ContactCreatedDomainEvent(ContactId));
        }

        internal ContactId ContactId { get; private set; }

        internal ContactLabelId ContactLabelId { get; private set; }

        internal AddressBookId AddressBookId { get; private set; }

        internal ContactName Name { get; private set; }

        internal ContactCompany Company { get; private set; }

        internal DateTime? Birthday { get; private set; }

        internal string Notes { get; private set; }

        internal byte?[] ContactPic { get; private set; }

        internal Address Address { get; private set; }

        internal bool IsFavorite { get; private set; }

        internal IReadOnlyCollection<Telephone> Telephones => telephones.AsReadOnly();

        internal IReadOnlyCollection<Email> Emails => emails.AsReadOnly();

        internal void AddTelephone(Telephone telephone)
        {
            this.CheckRule(new TelephoneCannotBeDuplicatedRule(telephones, telephone));
            telephones.Add(telephone);
        }

        internal void AddEmail(Email email)
        {
            this.CheckRule(new EmailCannotBeDuplicatedRule(emails, email));
            emails.Add(email);
        }

        internal void UpdateContactInfo(
            ContactName newName, ContactCompany newCompany, DateTime? newBirthday, string newNotes)
        {
            Name = newName ?? Name;
            Company = newCompany ?? Company;
            Birthday = newBirthday ?? Birthday;
            Notes = newNotes ?? Notes;
        }

        internal void AssignLabel(ContactLabelId contactLabelId) => ContactLabelId = contactLabelId;

        internal void ChangeAddress(Address address) => Address = address;

        internal void MarkContactAsFavorite() => IsFavorite = true;

        internal void RemoveFromFavorites() => IsFavorite = false;

        internal void RemoveTelephone(Telephone telephone) => telephones.Remove(telephone);

        internal void RemoveEmail(Email email) => emails.Remove(email);

        internal void RemoveLabel() => ContactLabelId = null;

        internal static Contact Create(
            AddressBookId addressBookId,
            ContactName name,
            ContactCompany company,
            DateTime? birthday,
            string notes,
            Address address,
            List<Telephone> telephones,
            List<Email> emails)
        {
            return new Contact(
                addressBookId, name, company, birthday, notes, address, telephones, emails);
        }
    }
}
