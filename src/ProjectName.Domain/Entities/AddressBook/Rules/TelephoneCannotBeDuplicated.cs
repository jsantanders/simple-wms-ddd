using System.Collections.Generic;
using System.Linq;
using ProjectName.Domain.Contracts;

namespace ProjectName.Domain.Entities.AddressBook.Rules
{
    public class TelephoneCannotBeDuplicated : IBusinessRule
    {
        private readonly List<Telephone> telephones;
        private readonly Telephone telephone;

        public TelephoneCannotBeDuplicated(List<Telephone> telephones, Telephone telephone)
        {
            this.telephones = telephones;
            this.telephone = telephone;
        }

        public string Message => "This telephone alredy exist for this contact.";

        public bool IsBroken() => telephones.Any(t => t == telephone);
    }
}
