using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ProjectName.Application.SeedWork;
using ProjectName.Application.SeedWork.Commands;
using ProjectName.Domain.Contracts;
using ProjectName.Domain.Entities.AddressBooks;

namespace ProjectName.Application.AddressBooks.AddContact
{
    internal class AddContactCommandHandler : ICommandHandler<AddContactCommand, Guid>
    {
        private readonly IExecutionContextAccessor contextAccessor;
        private readonly IRepository repository;

        public AddContactCommandHandler(
            IExecutionContextAccessor contextAccessor,
            IRepository repository)
        {
            this.contextAccessor = contextAccessor;
            this.repository = repository;
        }

        public async Task<Guid> Handle(AddContactCommand request, CancellationToken cancellationToken)
        {
            AddressBook addressBook =
                await repository.SingleOrDefault<AddressBook>(
                    ab => ab.UserId.Value == contextAccessor.UserId);

            var telephones = new List<Telephone>();
            var emails = new List<Email>();

            foreach (var telephone in request.Telephones)
            {
                telephones.Add(Telephone.Create(telephone.TelephoneType, telephone.Telephone));
            }

            foreach (var email in request.Emails)
            {
                emails.Add(Email.Create(email.EmailType, email.Email));
            }

            var contactId = addressBook.AddContact(
                ContactName.Create(request.FirstName, request.MiddleName, request.LastName),
                ContactCompany.Create(request.CompanyName, request.CompanyTitle),
                request.Birthday,
                request.Notes,
                Address.Create(request.Country, request.State, request.City, request.AddressLine1, request.AddressLine2),
                telephones,
                emails);

            return contactId.Value;
        }
    }
}
