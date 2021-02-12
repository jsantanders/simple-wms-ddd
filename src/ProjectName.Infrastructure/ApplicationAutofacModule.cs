using Autofac;
using ProjectName.Application.Common;

namespace ProjectName.Infrastructure
{
    public class ApplicationAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Executor>()
                .As<IExecutor>()
                .InstancePerLifetimeScope();
        }
    }
}