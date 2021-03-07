using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProjectName.Application.SeedWork;
using ProjectName.Application.SeedWork.Commands;
using ProjectName.Domain.Contracts;
using ProjectName.Domain.Entities.AddressBooks;

namespace ProjectName.Application.AddressBooks.UpdateContactInfo
{
    internal class UpdateContactInfoCommandHandler : ICommandHandler<UpdateContactInfoCommand>
    {
        private readonly IRepository repository;
        private readonly IExecutionContextAccessor executionContextAccessor;

        public UpdateContactInfoCommandHandler(
            IRepository repository,
            IExecutionContextAccessor executionContextAccessor)
        {
            this.repository = repository;
            this.executionContextAccessor = executionContextAccessor;
        }

        public async Task<Unit> Handle(UpdateContactInfoCommand request, CancellationToken cancellationToken)
        {
            var addressBook = await repository.SingleOrDefault<AddressBook>(
                ab => ab.UserId.Value == executionContextAccessor.UserId);

            addressBook.UpdateContactInfo(
                new ContactId(request.ContactId),
                ContactName.Create(request.FirstName, request.MiddleName, request.LastName),
                ContactCompany.Create(request.CompanyName, request.CompanyTitle),
                request.Birthday,
                request.Notes);

            return Unit.Value;
        }
    }
}
