using ProjectName.Domain.Contracts;

namespace ProjectName.Domain.Entities.AddressBookAggregate.Rules
{
    public class ContactLabelColorCannotBeNullOrEmpty : IBusinessRule
    {
        private readonly string color;

        public ContactLabelColorCannotBeNullOrEmpty(string color)
        {
            this.color = color;
        }

        public string Message => "Color cannot be empty.";

        public bool IsBroken() => string.IsNullOrEmpty(color);
    }
}
