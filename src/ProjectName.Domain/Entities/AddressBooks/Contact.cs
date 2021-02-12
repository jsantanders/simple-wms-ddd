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
            // Only for EF.
        }

        private Contact(
            AddressBookId addressBookId,
            ContactName name,
            ContactCompany company,
            DateTime? birthday,
            string notes,
            byte?[] contactPic,
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
            ContactPic = contactPic;
            Address = address;
            this.telephones = telephones ?? new List<Telephone>();
            this.emails = emails ?? new List<Email>();

            this.AddDomainEvent(new ContactCreatedDomainEvent(ContactId));
        }

        public ContactId ContactId { get; private set; }

        public ContactLabelId ContactLabelId { get; private set; }

        public AddressBookId AddressBookId { get; private set; }

        public ContactName Name { get; private set; }

        public ContactCompany Company { get; private set; }

        public DateTime? Birthday { get; private set; }

        public string Notes { get; private set; }

        public byte?[] ContactPic { get; private set; }

        public Address Address { get; private set; }

        public bool IsFavorite { get; private set; }

        public IReadOnlyCollection<Telephone> Telephones => telephones.AsReadOnly();

        public IReadOnlyCollection<Email> Emails => emails.AsReadOnly();

        public void AddTelephone(Telephone telephone)
        {
            this.CheckRule(new TelephoneCannotBeDuplicated(telephones, telephone));
            telephones.Add(telephone);
        }

        public void AddEmail(Email email)
        {
            this.CheckRule(new EmailCannotBeDuplicated(emails, email));
            emails.Add(email);
        }

        public void UpdateContactInfo(
            ContactName newName, ContactCompany newCompany, DateTime? newBirthday, string newNotes)
        {
            Name = newName ?? Name;
            Company = newCompany ?? Company;
            Birthday = newBirthday ?? Birthday;
            Notes = newNotes ?? Notes;
        }

        public void AssignLabel(ContactLabelId contactLabelId) => ContactLabelId = contactLabelId;

        public void ChangeAddress(Address address) => Address = address;

        public void MarkContactAsFavorite() => IsFavorite = true;

        public void RemoveFromFavorites() => IsFavorite = false;

        public void RemoveTelephone(Telephone telephone) => telephones.Remove(telephone);

        public void RemoveEmail(Email email) => emails.Remove(email);

        public void RemoveLabel() => ContactLabelId = null;

        internal static Contact Create(
            AddressBookId addressBookId,
            ContactName name,
            ContactCompany company,
            DateTime? birthday,
            string notes,
            byte?[] contactPic,
            Address address,
            List<Telephone> telephones,
            List<Email> emails)
        {
            return new Contact(
                addressBookId, name, company, birthday, notes, contactPic, address, telephones, emails);
        }
    }
}
