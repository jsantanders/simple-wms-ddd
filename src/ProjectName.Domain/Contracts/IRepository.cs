using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProjectName.Domain.SharedKernel;

namespace ProjectName.Domain.Contracts
{
    public interface IRepository
    {
        Task<T> GetById<T>(StronglyTypedIdBase id)
            where T : class, IAggregateRoot;

        Task<T> SingleOrDefault<T>(Expression<Func<T, bool>> predicate)
            where T : class, IAggregateRoot;

        Task Create<T>(T entity)
            where T : EntityBase<StronglyTypedIdBase>, IAggregateRoot;

        void Delete<T>(T entity)
            where T : EntityBase<StronglyTypedIdBase>, IAggregateRoot;
    }
}
