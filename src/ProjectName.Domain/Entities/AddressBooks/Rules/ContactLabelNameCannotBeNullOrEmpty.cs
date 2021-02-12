using ProjectName.Domain.Contracts;

namespace ProjectName.Domain.Entities.AddressBooks.Rules
{
    public class ContactLabelNameCannotBeNullOrEmpty : IBusinessRule
    {
        private readonly string labelName;

        public ContactLabelNameCannotBeNullOrEmpty(string labelName)
        {
            this.labelName = labelName;
        }

        public string Message => "Label name cannot be empty.";

        public bool IsBroken() => string.IsNullOrEmpty(labelName);
    }
}
