using System;
using ProjectName.Domain.SharedKernel;

namespace ProjectName.Domain.Entities.AddressBooks
{
    public class ContactId : StronglyTypedIdBase
    {
        public ContactId(Guid value)
        : base(value)
        {
        }
    }
}
