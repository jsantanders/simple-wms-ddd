using System;
using ProjectName.Application.SeedWork.Commands;

namespace ProjectName.Application.AddressBooks.UpdateContactInfo
{
    public class UpdateContactInfoCommand : CommandBase
    {
        public UpdateContactInfoCommand(
            Guid contactId,
            string firstName,
            string middleName,
            string lastName,
            string companyName,
            string companyTitle,
            DateTime? birthday,
            string notes)
        {
            ContactId = contactId;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            CompanyName = companyName;
            CompanyTitle = companyTitle;
            Birthday = birthday;
            Notes = notes;
        }

        public Guid ContactId { get; }

        public string FirstName { get; }

        public string MiddleName { get; }

        public string LastName { get; }

        public string CompanyName { get; }

        public string CompanyTitle { get; }

        public DateTime? Birthday { get; }

        public string Notes { get; }
    }
}