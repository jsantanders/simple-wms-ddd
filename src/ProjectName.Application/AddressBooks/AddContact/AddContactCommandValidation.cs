using FluentValidation;

namespace ProjectName.Application.AddressBooks.AddContact
{
    public class AddContactCommandValidation : AbstractValidator<AddContactCommand>
    {
        public AddContactCommandValidation()
        {
            RuleFor(f => f.FirstName).NotEmpty();
            RuleFor(f => f.LastName).NotEmpty();
        }
    }
}
