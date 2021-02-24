using System.Collections.Generic;
using System.Linq;
using ProjectName.Domain.Contracts;

namespace ProjectName.Domain.Entities.AddressBooks.Rules
{
    public class TelephoneCannotBeDuplicatedRule : IBusinessRule
    {
        private readonly List<Telephone> telephones;
        private readonly Telephone telephone;

        public TelephoneCannotBeDuplicatedRule(List<Telephone> telephones, Telephone telephone)
        {
            this.telephones = telephones;
            this.telephone = telephone;
        }

        public string Message => "This telephone already exist for this contact.";

        public bool IsBroken() => telephones.Any(t => t == telephone);
    }
}
