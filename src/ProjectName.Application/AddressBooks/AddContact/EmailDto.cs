using ProjectName.Domain.Entities.AddressBooks;

namespace ProjectName.Application.AddressBooks.AddContact
{
    public class EmailDto
    {
        public EmailDto(EmailType emailType, string email)
        {
            EmailType = emailType;
            Email = email;
        }

        public EmailType EmailType { get; }

        public string Email { get; }
    }
}
