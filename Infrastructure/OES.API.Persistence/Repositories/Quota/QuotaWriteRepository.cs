using OES.API.Application.Repositories;
using OES.API.Domain.Entities;
using OES.API.Persistence.Contexts;

namespace OES.API.Persistence.Repositories
{
    public class QuotaWriteRepository : WriteRepository<Quota>, IQuotaWriteRepository
    {
        public QuotaWriteRepository(OESAPIDbContext dbContext) : base(dbContext)
        {
        }
    }
}
