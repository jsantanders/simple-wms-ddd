using ProjectName.Domain.Contracts;

namespace ProjectName.Domain.Entities.AddressBooks.Rules
{
    public class ContactFirstNameCannotBeNullOrEmpty : IBusinessRule
    {
        private readonly string firstName;

        public ContactFirstNameCannotBeNullOrEmpty(string firstName)
        {
            this.firstName = firstName;
        }

        public string Message => "Contact first name cannot be empty.";

        public bool IsBroken() => string.IsNullOrEmpty(firstName);
    }
}
