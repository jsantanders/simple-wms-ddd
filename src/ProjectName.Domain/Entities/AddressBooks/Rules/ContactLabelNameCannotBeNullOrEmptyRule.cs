using ProjectName.Domain.Contracts;

namespace ProjectName.Domain.Entities.AddressBooks.Rules
{
    public class ContactLabelNameCannotBeNullOrEmptyRule : IBusinessRule
    {
        private readonly string labelName;

        public ContactLabelNameCannotBeNullOrEmptyRule(string labelName)
        {
            this.labelName = labelName;
        }

        public string Message => "Label name cannot be empty.";

        public bool IsBroken() => string.IsNullOrEmpty(labelName);
    }
}
