using Autofac;
using ProjectName.Application.SeedWork;
using ProjectName.Infrastructure.Configurations.DataAccess;
using ProjectName.Infrastructure.Configurations.Logging;
using ProjectName.Infrastructure.Configurations.Mediation;
using ProjectName.Infrastructure.Configurations.Processing;
using Serilog;

namespace ProjectName.Infrastructure
{
    public static class StartupSetup
    {
        private static IContainer container;

        public static void Initialize(
            string connectionString,
            IExecutionContextAccessor executionContextAccessor,
            ILogger logger)
        {
            ConfigureCompositionRoot(
                connectionString,
                executionContextAccessor,
                logger);
        }

        private static void ConfigureCompositionRoot(
            string connectionString,
            IExecutionContextAccessor executionContextAccessor,
            ILogger logger)
        {
            var containerBuilder = new ContainerBuilder();

            // Be careful, order matters.
            containerBuilder.RegisterModule(new LoggingModule(logger));
            containerBuilder.RegisterModule(new ProcessingModule());
            containerBuilder.RegisterModule(new DataAccessModule(connectionString));
            containerBuilder.RegisterModule(new MediatorModule());

            containerBuilder.RegisterInstance(executionContextAccessor);

            container = containerBuilder.Build();

            ApplicationCompositionRoot.SetContainer(container);
        }
    }
}