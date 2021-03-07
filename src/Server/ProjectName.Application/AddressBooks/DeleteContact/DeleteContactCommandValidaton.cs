using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace ProjectName.Application.AddressBooks.DeleteContact
{
    class DeleteContactCommandValidaton : AbstractValidator<DeleteContactCommand>
    {
        public DeleteContactCommandValidaton()
        {
            RuleFor(c => c.ContactId).NotEmpty();
        }
    }
}
