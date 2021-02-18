using System;
using System.Threading;
using System.Threading.Tasks;
using ProjectName.Application.SeedWork.Commands;
using ProjectName.Infrastructure.Data;

namespace ProjectName.Infrastructure.Configurations.Processing
{
    internal class UnitOfWorkCommandHandlerWithResultDecorator<T, TResult> : ICommandHandler<T, TResult>
        where T : ICommand<TResult>
    {
        private readonly ICommandHandler<T, TResult> decorated;
        private readonly IUnitOfWork unitOfWork;

        public UnitOfWorkCommandHandlerWithResultDecorator(
            ICommandHandler<T, TResult> decorated,
            IUnitOfWork unitOfWork)
        {
            this.decorated = decorated;
            this.unitOfWork = unitOfWork;
        }

        public async Task<TResult> Handle(T command, CancellationToken cancellationToken)
        {
            var result = await this.decorated.Handle(command, cancellationToken);

            await this.unitOfWork.CommitAsync(cancellationToken);

            return result;
        }
    }
}
