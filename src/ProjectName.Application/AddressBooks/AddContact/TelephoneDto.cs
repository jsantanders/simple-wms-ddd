using ProjectName.Domain.Entities.AddressBooks;

namespace ProjectName.Application.AddressBooks.AddContact
{
    public class TelephoneDto
    {
        public TelephoneDto(TelephoneType telephoneType, string telephone)
        {
            TelephoneType = telephoneType;
            Telephone = telephone;
        }

        public TelephoneType TelephoneType { get; }

        public string Telephone { get; }
    }
}
