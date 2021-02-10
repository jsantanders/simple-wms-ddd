using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectName.Domain.Contracts;

namespace ProjectName.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public async Task<int> CommitAsync(
            CancellationToken cancellationToken = default)
        {
            return await context.SaveChangesAsync(cancellationToken);
        }
    }
}