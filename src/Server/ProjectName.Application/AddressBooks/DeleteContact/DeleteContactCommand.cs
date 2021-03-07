using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectName.Application.SeedWork.Commands;

namespace ProjectName.Application.AddressBooks.DeleteContact
{
    public class DeleteContactCommand : CommandBase
    {
        public DeleteContactCommand(Guid contactId)
        {
            ContactId = contactId;
        }

        public Guid ContactId { get; }
    }
}
