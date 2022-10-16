using Microsoft.EntityFrameworkCore;
using OES.API.Application.Repositories;
using OES.API.Domain.Entities.Common;
using OES.API.Persistence.Contexts;
using System.Linq.Expressions;

namespace OES.API.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly OESAPIDbContext _dbContext;

        public ReadRepository(OESAPIDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<T> Table => _dbContext.Set<T>();
        public IQueryable<T> GetAll()
        {
            var query = Table.AsQueryable();
            return query;
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var query = Table.AsQueryable();
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        {
            var query = Table.AsQueryable();
            return await query.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        {
            var query = Table.AsQueryable();
            return query.Where(method);
        }

        public void EnableLazyLoading()
        {
            _dbContext.ChangeTracker.LazyLoadingEnabled = true;
        }
    }
}
