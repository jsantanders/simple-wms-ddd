using System;
using ProjectName.Domain.SharedKernel;

namespace ProjectName.Domain.Entities.Users
{
    public class UserId : StronglyTypedIdBase
    {
        protected UserId(Guid value)
            : base(value)
        {
        }
    }
}
