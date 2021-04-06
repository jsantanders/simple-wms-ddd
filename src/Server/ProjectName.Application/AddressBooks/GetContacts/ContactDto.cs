using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectName.Domain.Entities.AddressBooks;

namespace ProjectName.Application.AddressBooks.GetContacts
{
    public record ContactDto
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string CompanyName { get; set; }

        public string CompanyTitle { get; set; }

        public EmailType EmailType { get; set; }

        public string EmailValue { get; set; }

        public TelephoneType TelephoneType { get; set; }

        public string PhoneNumber { get; set; }

        public string LabelName { get; set; }

        public string LabelColor { get; set; }
    }
}
