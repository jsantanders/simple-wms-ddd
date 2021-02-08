using ProjectName.Domain.Entities.AddressBook.Rules;
using ProjectName.Domain.SharedKernel;

namespace ProjectName.Domain.Entities.AddressBook
{
    public class ContactName : ValueObject
    {
        public string FirstName { get; }

        public string MiddleName { get; }

        public string LastName { get; }

        private ContactName(
            string firstName, string middleName, string lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

        public static ContactName Create(
            string firstName, string middleName, string lastName)
        {
            CheckRule(new ContactFirstNameCannotBeNullOrEmpty(firstName));
            return new ContactName(firstName, middleName, lastName);
        }
    }
}
