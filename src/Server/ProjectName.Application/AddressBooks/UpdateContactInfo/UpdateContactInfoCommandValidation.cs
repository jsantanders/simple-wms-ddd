using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace ProjectName.Application.AddressBooks.UpdateContactInfo
{
    internal class UpdateContactInfoCommandValidation : AbstractValidator<UpdateContactInfoCommand>
    {
        public UpdateContactInfoCommandValidation()
        {
            RuleFor(e => e.ContactId).NotEmpty();
        }
    }
}
