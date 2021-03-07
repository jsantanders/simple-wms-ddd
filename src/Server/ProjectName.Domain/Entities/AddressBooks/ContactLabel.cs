using System;
using System.Text.RegularExpressions;
using Ardalis.GuardClauses;
using ProjectName.Domain.Entities.AddressBooks.Rules;
using ProjectName.Domain.SharedKernel;

namespace ProjectName.Domain.Entities.AddressBooks
{
    public class ContactLabel : EntityBase<ContactLabelId>
    {
        private const string ValidHexColorPattern = @"^#([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$";

        private ContactLabel()
        {
        }

        private ContactLabel(AddressBookId addressBookId, string name, string color)
        {
            this.CheckRule(new ContactLabelNameCannotBeNullOrEmptyRule(name));
            this.CheckRule(new ContactLabelColorCannotBeNullOrEmptyRule(color));

            ContactLabelId = new ContactLabelId(Guid.NewGuid());
            AddressBookId = addressBookId;
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
            Color = color;
        }

        internal ContactLabelId ContactLabelId { get; private set; }

        internal AddressBookId AddressBookId { get; private set; }

        internal string Name { get; private set; }

        internal string Color { get; private set; }

        internal static ContactLabel Create(AddressBookId addressBookId, string name, string color)
        {
            bool isValidColor = Regex.Match(color, ValidHexColorPattern).Success;
            if (!isValidColor)
            {
                throw new ArgumentException("The color format is invalid");
            }

            return new ContactLabel(addressBookId, name, color);
        }
    }
}
