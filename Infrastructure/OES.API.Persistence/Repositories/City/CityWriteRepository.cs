using OES.API.Application.Repositories;
using OES.API.Domain.Entities;
using OES.API.Persistence.Contexts;

namespace OES.API.Persistence.Repositories
{
    public class CityWriteRepository : WriteRepository<City>, ICityWriteRepository
    {
        public CityWriteRepository(OESAPIDbContext dbContext) : base(dbContext)
        {
        }
    }
}
