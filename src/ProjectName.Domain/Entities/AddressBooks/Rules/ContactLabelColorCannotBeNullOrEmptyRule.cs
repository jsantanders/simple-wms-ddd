using ProjectName.Domain.Contracts;

namespace ProjectName.Domain.Entities.AddressBooks.Rules
{
    public class ContactLabelColorCannotBeNullOrEmptyRule : IBusinessRule
    {
        private readonly string color;

        public ContactLabelColorCannotBeNullOrEmptyRule(string color)
        {
            this.color = color;
        }

        public string Message => "Color cannot be empty.";

        public bool IsBroken() => string.IsNullOrEmpty(color);
    }
}
