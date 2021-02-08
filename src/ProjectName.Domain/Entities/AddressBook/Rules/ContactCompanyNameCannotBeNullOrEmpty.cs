using ProjectName.Domain.Contracts;

namespace ProjectName.Domain.Entities.AddressBook.Rules
{
    public class ContactCompanyNameCannotBeNullOrEmpty : IBusinessRule
    {
        private readonly string companyName;

        public ContactCompanyNameCannotBeNullOrEmpty(string companyName)
        {
            this.companyName = companyName;
        }

        public string Message => "Contact company name cannot be empty.";

        public bool IsBroken() => string.IsNullOrEmpty(companyName);
    }
}
