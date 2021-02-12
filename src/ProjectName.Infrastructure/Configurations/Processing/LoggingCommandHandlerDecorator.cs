using System;
using System.Threading;
using System.Threading.Tasks;
using ProjectName.Application.Common;
using MediatR;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Events;


namespace ProjectName.Infrastructure.Configurations.Processing
{
    internal class LoggingCommandHandlerDecorator<T> : ICommandHandler<T>
        where T : ICommand
    {
        private readonly ILogger logger;
        private readonly IExecutionContextAccessor executionContextAccessor;
        private readonly ICommandHandler<T> decorated;

        public LoggingCommandHandlerDecorator(
            ILogger logger,
            IExecutionContextAccessor executionContextAccessor,
            ICommandHandler<T> decorated)
        {
            this.logger = logger;
            this.executionContextAccessor = executionContextAccessor;
            this.decorated = decorated;
        }

        public async Task<Unit> Handle(T command, CancellationToken cancellationToken)
        {

            using (
                LogContext.Push(
                    new RequestLogEnricher(executionContextAccessor),
                    new CommandLogEnricher(command)))
            {
                try
                {
                    this.logger.Information(
                        "Executing command {Command}",
                        command.GetType().Name);

                    var result = await decorated.Handle(command, cancellationToken);

                    this.logger.Information("Command {Command} processed successful", command.GetType().Name);

                    return result;
                }
                catch (Exception exception)
                {
                    this.logger.Error(exception, "Command {Command} processing failed", command.GetType().Name);
                    throw;
                }
            }
        }

        private class CommandLogEnricher : ILogEventEnricher
        {
            private readonly ICommand command;

            public CommandLogEnricher(ICommand command)
            {
                this.command = command;
            }

            public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
            {
                logEvent.AddOrUpdateProperty(new LogEventProperty("Context", new ScalarValue($"Command:{command.Id.ToString()}")));
            }
        }

        private class RequestLogEnricher : ILogEventEnricher
        {
            private readonly IExecutionContextAccessor executionContextAccessor;

            public RequestLogEnricher(IExecutionContextAccessor executionContextAccessor)
            {
                this.executionContextAccessor = executionContextAccessor;
            }

            public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
            {
                if (executionContextAccessor.IsAvailable)
                {
                    logEvent.AddOrUpdateProperty(new LogEventProperty("CorrelationId", new ScalarValue(executionContextAccessor.CorrelationId)));
                }
            }
        }
    }
}