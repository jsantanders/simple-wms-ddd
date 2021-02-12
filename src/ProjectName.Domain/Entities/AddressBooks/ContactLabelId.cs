using System;
using ProjectName.Domain.SharedKernel;

namespace ProjectName.Domain.Entities.AddressBooks
{
    public class ContactLabelId : StronglyTypedIdBase
    {
        public ContactLabelId(Guid value)
        : base(value)
        {
        }
    }
}
