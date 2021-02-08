using System;
using System.Threading.Tasks;
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

        public Task<T> Create<T>(T entity) where T : EntityBase
        {
            throw new NotImplementedException();
        }

        public Task<T> Delete<T>(T entity) where T : EntityBase
        {
            throw new NotImplementedException();
        }

        public T GetById<T>(Guid Id) where T : EntityBase
        {
            throw new NotImplementedException();
        }
    }
}
