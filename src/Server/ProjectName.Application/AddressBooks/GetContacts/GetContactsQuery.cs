using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectName.Application.SeedWork.Queries;

namespace ProjectName.Application.AddressBooks.GetContacts
{
    public class GetContactsQuery : QueryBase<IEnumerable<ContactDto>>
    {
        public GetContactsQuery()
        {
        }
    }
}
