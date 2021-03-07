using System.Collections.Generic;
using System.Linq;
using ProjectName.Domain.Contracts;

namespace ProjectName.Domain.Entities.AddressBooks.Rules
{
    public class EmailCannotBeDuplicatedRule : IBusinessRule
    {
        private readonly List<Email> emails;
        private readonly Email email;

        public EmailCannotBeDuplicatedRule(List<Email> emails, Email email)
        {
            this.emails = emails;
            this.email = email;
        }

        public string Message => "This email already exist for this contact.";

        public bool IsBroken() => emails.Any(t => t == email);
    }
}
