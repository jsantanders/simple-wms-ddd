using ProjectName.Domain.SharedKernel;

namespace ProjectName.Domain.Entities.AddressBook
{
    public class Address : ValueObject
    {
        public string Country { get; }

        public string State { get; }

        public string City { get; }

        public string AddressLine1 { get; }

        public string AddressLine2 { get; }

        private Address(
            string country,
            string state,
            string city,
            string addressLine1,
            string addressLine2)
        {
            Country = country;
            State = state;
            City = city;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
        }

        public static Address Create(
            string country,
            string state,
            string city,
            string addressLine1,
            string addressLine2)
        {
            return new Address(
                country, state, city, addressLine1, addressLine2);
        }
    }
}
