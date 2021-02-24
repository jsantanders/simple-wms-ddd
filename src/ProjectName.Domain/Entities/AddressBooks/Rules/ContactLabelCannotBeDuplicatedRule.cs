using ProjectName.Domain.Contracts;

namespace ProjectName.Domain.Entities.AddressBooks.Rules
{
    public class ContactLabelCannotBeDuplicatedRule : IBusinessRule
    {
        private readonly string name;
        private readonly string color;

        public string Message => throw new System.NotImplementedException();

        public ContactLabelCannotBeDuplicatedRule(string name, string color)
        {
            this.name = name;
            this.color = color;
        }

        public bool IsBroken()
        {
            throw new System.NotImplementedException();
        }
    }
}
