using Autofac;
using ProjectName.Application;
using ProjectName.Infrastructure.Data;

namespace ProjectName.Infrastructure
{
    public class ContainerSetup
    {
        public static IContainer Initialize(string connectionString)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<SqlConnectionFactory>()
                .As<ISqlConnectionFactory>()
                .WithParameter("connectionString", connectionString)
                .InstancePerLifetimeScope();

            return builder.Build();
        }
    }
}
