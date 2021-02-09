using System;
using ProjectName.Domain.SharedKernel;

namespace ProjectName.Domain.Entities.AddressBookAggregate
{
    public class ContactLabelId : StronglyTypedIdBase
    {
        public ContactLabelId(Guid value)
        : base(value)
        {
        }
    }
}
