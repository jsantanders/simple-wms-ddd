using System;
using ProjectName.Domain.SharedKernel;

namespace ProjectName.Domain.Entities.AddressBooks
{
    public class AddressBookId : StronglyTypedIdBase
    {
        public AddressBookId(Guid value)
            : base(value)
        {
        }
    }
}
