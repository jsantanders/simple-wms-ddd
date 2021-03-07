using System;
using System.Linq.Expressions;
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

        public async Task<T> GetById<T>(StronglyTypedIdBase id)
            where T : class, IAggregateRoot
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> SingleOrDefault<T>(Expression<Func<T, bool>> predicate)
            where T : class, IAggregateRoot
        {
            return await dbContext.Set<T>().SingleOrDefaultAsync(predicate);
        }

        public async Task Create<T>(T entity)
            where T : EntityBase<StronglyTypedIdBase>, IAggregateRoot
        {
            await dbContext.Set<T>().AddAsync(entity);
        }

        public void Delete<T>(T entity)
            where T : EntityBase<StronglyTypedIdBase>, IAggregateRoot
        {
            dbContext.Set<T>().Remove(entity);
        }
    }
}
