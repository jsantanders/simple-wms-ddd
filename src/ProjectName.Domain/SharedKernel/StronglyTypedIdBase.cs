using System;

namespace ProjectName.Domain.SharedKernel
{
    public class StronglyTypedIdBase : IEquatable<StronglyTypedIdBase>
    {
        public Guid Value { get; }

        protected StronglyTypedIdBase(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new InvalidOperationException("Id value cannot be empty!");
            }

            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            return obj is StronglyTypedIdBase other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public bool Equals(StronglyTypedIdBase other)
        {
            return this.Value == other?.Value;
        }

        public static bool operator ==(StronglyTypedIdBase obj1, StronglyTypedIdBase obj2)
        {
            if (object.Equals(obj1, null))
            {
                if (object.Equals(obj2, null))
                {
                    return true;
                }

                return false;
            }

            return obj1.Equals(obj2);
        }

        public static bool operator !=(StronglyTypedIdBase x, StronglyTypedIdBase y)
        {
            return !(x == y);
        }
    }
}
