using OES.API.Application.Repositories;
using OES.API.Domain.Entities;
using OES.API.Persistence.Contexts;

namespace OES.API.Persistence.Repositories
{
    public class QuotaReadRepository : ReadRepository<Quota>, IQuotaReadRepository
    {
        public QuotaReadRepository(OESAPIDbContext dbContext) : base(dbContext)
        {
        }
    }
}
