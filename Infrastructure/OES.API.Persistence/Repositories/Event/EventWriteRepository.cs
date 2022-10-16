using OES.API.Application.Repositories;
using OES.API.Domain.Entities;
using OES.API.Persistence.Contexts;

namespace OES.API.Persistence.Repositories
{
    public class EventWriteRepository : WriteRepository<Event>, IEventWriteRepository
    {
        public EventWriteRepository(OESAPIDbContext dbContext) : base(dbContext)
        {
        }
    }
}
