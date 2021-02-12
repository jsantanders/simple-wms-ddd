using ProjectName.Domain.Entities.AddressBooks.Rules;
using ProjectName.Domain.SharedKernel;

namespace ProjectName.Domain.Entities.AddressBooks
{
    public class ContactCompany : ValueObject
    {
        private ContactCompany(string companyName, string title)
        {
            CompanyName = companyName;
            Title = title;
        }

        public string CompanyName { get; }

        public string Title { get; }

        public static ContactCompany Create(string companyName, string title)
        {
            CheckRule(new ContactCompanyNameCannotBeNullOrEmpty(companyName));
            return new ContactCompany(companyName, title);
        }
    }
}
