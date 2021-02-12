using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProjectName.Application.Common;
using ProjectName.Infrastructure.Data;

namespace ProjectName.Infrastructure.Configurations.Processing
{
    internal class UnitOfWorkCommandHandlerDecorator<T> : ICommandHandler<T>
        where T : ICommand
    {
        private readonly ICommandHandler<T> decorated;
        private readonly IUnitOfWork unitOfWork;

        public UnitOfWorkCommandHandlerDecorator(
            ICommandHandler<T> decorated,
            IUnitOfWork unitOfWork)
        {
            this.decorated = decorated;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(T command, CancellationToken cancellationToken)
        {
            await this.decorated.Handle(command, cancellationToken);

            await this.unitOfWork.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}