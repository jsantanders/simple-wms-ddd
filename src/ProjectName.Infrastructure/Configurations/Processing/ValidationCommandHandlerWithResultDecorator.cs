using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using ProjectName.Application.Common;

namespace ProjectName.Infrastructure.Configurations.Processing
{
    internal class ValidationCommandHandlerWithResultDecorator<T, TResult> : ICommandHandler<T, TResult>
        where T : ICommand<TResult>
    {
        private readonly IList<IValidator<T>> validators;

        private readonly ICommandHandler<T, TResult> decorated;

        public ValidationCommandHandlerWithResultDecorator(
            IList<IValidator<T>> validators,
            ICommandHandler<T, TResult> decorated)
        {
            this.validators = validators;
            this.decorated = decorated;
        }

        public Task<TResult> Handle(T command, CancellationToken cancellationToken)
        {
            var errors = validators
                .Select(v => v.Validate(command))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (errors.Any())
            {
                throw new InvalidCommandException(errors.Select(x => x.ErrorMessage).ToList());
            }

            return decorated.Handle(command, cancellationToken);
        }
    }
}