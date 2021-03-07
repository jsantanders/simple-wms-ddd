using ProjectName.Domain.Contracts;

namespace ProjectName.Domain.Entities.AddressBooks.Rules
{
    public class ContactCompanyNameCannotBeNullOrEmptyRule : IBusinessRule
    {
        private readonly string companyName;

        public ContactCompanyNameCannotBeNullOrEmptyRule(string companyName)
        {
            this.companyName = companyName;
        }

        public string Message => "Contact company name cannot be empty.";

        public bool IsBroken() => string.IsNullOrEmpty(companyName);
    }
}
