using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ProjectName.Application.SeedWork.Commands;

namespace ProjectName.Application.AddressBooks.AddContact
{
    public class AddContactCommand : CommandBase<Guid>
    {
        private readonly List<TelephoneDto> telephones;

        private readonly List<EmailDto> emails;

        public AddContactCommand(
            string firstName,
            string middleName,
            string lastName,
            string companyName,
            string companyTitle,
            DateTime? birthday,
            string notes,
            string country,
            string state,
            string city,
            string addressLine1,
            string addressLine2,
            List<TelephoneDto> telephones,
            List<EmailDto> emails)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            CompanyName = companyName;
            CompanyTitle = companyTitle;
            Birthday = birthday;
            Notes = notes;
            Country = country;
            State = state;
            City = city;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            this.telephones = telephones;
            this.emails = emails;
        }

        public string FirstName { get; }

        public string MiddleName { get; }

        public string LastName { get; }

        public string CompanyName { get; }

        public string CompanyTitle { get; }

        public DateTime? Birthday { get; }

        public string Notes { get; }

        public string Country { get; }

        public string State { get; }

        public string City { get; }

        public string AddressLine1 { get; }

        public string AddressLine2 { get; }

        public IEnumerable<TelephoneDto> Telephones => telephones;

        public IEnumerable<EmailDto> Emails => emails;
    }
}
