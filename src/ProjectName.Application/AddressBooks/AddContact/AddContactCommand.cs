using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ProjectName.Application.SeedWork.Commands;

namespace ProjectName.Application.AddressBooks.AddContact
{
    [DataContract]
    public class AddContactCommand : CommandBase<Guid>
    {
        [DataMember]
        private readonly List<TelephoneDto> telephones;

        [DataMember]
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

        [DataMember]
        public string FirstName { get; }

        [DataMember]
        public string MiddleName { get; }

        [DataMember]
        public string LastName { get; }

        [DataMember]
        public string CompanyName { get; }

        [DataMember]
        public string CompanyTitle { get; }

        [DataMember]
        public DateTime? Birthday { get; }

        [DataMember]
        public string Notes { get; }

        [DataMember]
        public string Country { get; }

        [DataMember]
        public string State { get; }

        [DataMember]
        public string City { get; }

        [DataMember]
        public string AddressLine1 { get; }

        [DataMember]
        public string AddressLine2 { get; }

        [DataMember]
        public IEnumerable<TelephoneDto> Telephones => telephones;

        [DataMember]
        public IEnumerable<EmailDto> Emails => emails;
    }
}
