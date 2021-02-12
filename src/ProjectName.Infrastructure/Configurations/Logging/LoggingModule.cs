using Autofac;

namespace ProjectName.Infrastructure.Configurations.Logging
{
    public class LoggingModule : Module
    {
        private readonly ILogger logger;

        internal LoggingModule(ILogger logger)
        {
            this.logger = logger;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(logger)
                .As<ILogger>()
                .SingleInstance();
        }
    }
}