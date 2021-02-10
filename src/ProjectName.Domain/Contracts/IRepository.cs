using System.Threading.Tasks;
using ProjectName.Domain.SharedKernel;

namespace ProjectName.Domain.Contracts
{
    public interface IRepository
    {
        Task<T> GetById<T, TKey>(TKey id)
            where T : EntityBase<TKey>, IAggregateRoot
            where TKey : StronglyTypedIdBase;

        Task Create<T, TKey>(T entity)
            where T : EntityBase<TKey>, IAggregateRoot
            where TKey : StronglyTypedIdBase;

        void Delete<T, TKey>(T entity)
            where T : EntityBase<TKey>, IAggregateRoot
            where TKey : StronglyTypedIdBase;
    }
}