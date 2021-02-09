using System;
using ProjectName.Domain.SharedKernel;

namespace ProjectName.Domain.Entities.AddressBookAggregate
{
    public class AddressBookId : StronglyTypedIdBase
    {
        public AddressBookId(Guid value)
            : base(value)
        {
        }
    }
}
