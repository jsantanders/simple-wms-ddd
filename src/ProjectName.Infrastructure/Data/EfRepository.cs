using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectName.Domain.Contracts;
using ProjectName.Domain.SharedKernel;

namespace ProjectName.Infrastructure.Data
{
    public class EfRepository : IRepository
    {
        private readonly AppDbContext dbContext;

        public EfRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<T> GetById<T, TKey>(TKey id)
            where T : EntityBase<TKey>, IAggregateRoot
            where TKey : StronglyTypedIdBase
        {
            return await dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task Create<T, TKey>(T entity)
            where T : EntityBase<TKey>, IAggregateRoot
            where TKey : StronglyTypedIdBase
        {
            await dbContext.Set<T>().AddAsync(entity);
        }

        public void Delete<T, TKey>(T entity)
            where T : EntityBase<TKey>, IAggregateRoot
            where TKey : StronglyTypedIdBase
        {
            dbContext.Set<T>().Remove(entity);
        }
    }
}