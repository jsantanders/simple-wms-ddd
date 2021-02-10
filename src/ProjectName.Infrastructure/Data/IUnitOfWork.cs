using System.Threading;
using System.Threading.Tasks;

namespace ProjectName.Infrastructure.Data
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}