using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;
using ProjectName.Application.Common;
using ProjectName.Domain.Contracts;
using ProjectName.Infrastructure.Data;

namespace ProjectName.Infrastructure.Configurations.DataAccess
{
    public class DataAccessModule : Module
    {
        private readonly string databaseConnectionString;

        internal DataAccessModule(string databaseConnectionString)
        {
            this.databaseConnectionString = databaseConnectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqlConnectionFactory>()
                .As<ISqlConnectionFactory>()
                .WithParameter("connectionString", databaseConnectionString)
                .InstancePerLifetimeScope();

            builder
                .Register(c =>
                {
                    var dbContextOptionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                    dbContextOptionsBuilder.UseSqlServer(databaseConnectionString);

                    dbContextOptionsBuilder
                        .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();

                    var eventDispatcher = c.Resolve<IDomainEventDispatcher>();

                    return new AppDbContext(dbContextOptionsBuilder.Options, eventDispatcher);
                })
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EfRepository>()
                .As<IRepository>()
                .InstancePerLifetimeScope();
        }
    }
}