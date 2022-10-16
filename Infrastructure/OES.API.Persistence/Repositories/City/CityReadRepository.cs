using OES.API.Application.Repositories;
using OES.API.Domain.Entities;
using OES.API.Persistence.Contexts;

namespace OES.API.Persistence.Repositories
{
    public class CityReadRepository : ReadRepository<City>, ICityReadRepository
    {
        public CityReadRepository(OESAPIDbContext dbContext) : base(dbContext)
        {
        }
    }
}
