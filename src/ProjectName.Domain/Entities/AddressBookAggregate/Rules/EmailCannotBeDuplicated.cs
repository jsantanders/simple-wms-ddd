using System.Collections.Generic;
using System.Linq;
using ProjectName.Domain.Contracts;

namespace ProjectName.Domain.Entities.AddressBookAggregate.Rules
{
    public class EmailCannotBeDuplicated : IBusinessRule
    {
        private readonly List<Email> emails;
        private readonly Email email;

        public EmailCannotBeDuplicated(List<Email> emails, Email email)
        {
            this.emails = emails;
            this.email = email;
        }

        public string Message => "This email alredy exist for this contact.";

        public bool IsBroken() => emails.Any(t => t == email);
    }
}
