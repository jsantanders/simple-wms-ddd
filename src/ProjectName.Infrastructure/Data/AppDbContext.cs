using System.Linq;
using System.Reflection;
using ProjectName.Domain.Contracts;
using ProjectName.Domain.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace ProjectName.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IDomainEventDispatcher dispatcher;

        public AppDbContext(DbContextOptions<AppDbContext> options, IDomainEventDispatcher dispatcher)
            : base(options)
        {
            this.dispatcher = dispatcher;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            int result = base.SaveChanges();

            if(dispatcher is null) return result;

            var entityWithEvents = this.ChangeTracker.Entries<EntityBase<StronglyTypedIdBase>>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach(var entity in entityWithEvents)
            {
                var events = entity.Events.ToArray();
                entity.ClearDomainEvents();
                foreach (var @event in events)
                {
                    this.dispatcher.Dispatch(@event);
                }
            }

            return result;
        }
    }
}
