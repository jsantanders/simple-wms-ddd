using System.Threading.Tasks;
using ProjectName.Domain.SharedKernel;

namespace ProjectName.Domain.Contracts
{
    public interface IRepository
    {
        T GetById<T, TKey>(TKey id)
            where T : EntityBase, IAggregateRoot
            where TKey : StronglyTypedIdBase;

        Task<T> Create<T>(T entity)
        where T : EntityBase, IAggregateRoot;

        Task<T> Delete<T>(T entity)
        where T : EntityBase, IAggregateRoot;
    }
}
