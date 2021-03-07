using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProjectName.Application.SeedWork;
using ProjectName.Application.SeedWork.Commands;
using ProjectName.Domain.Contracts;
using ProjectName.Domain.Entities.AddressBooks;

namespace ProjectName.Application.AddressBooks.DeleteContact
{
    internal class DeleteContactCommandHandler : ICommandHandler<DeleteContactCommand>
    {
        private readonly IRepository repository;
        private readonly IExecutionContextAccessor executionContextAccessor;

        public DeleteContactCommandHandler(
            IRepository repository,
            IExecutionContextAccessor executionContextAccessor)
        {
            this.repository = repository;
            this.executionContextAccessor = executionContextAccessor;
        }

        public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var addressBook = await repository.SingleOrDefault<AddressBook>(
                ab => ab.UserId.Value == executionContextAccessor.UserId);

            addressBook.RemoveContact(new ContactId(request.ContactId));

            return Unit.Value;
        }
    }
}
