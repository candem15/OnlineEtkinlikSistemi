using OES.API.Application.Repositories;
using OES.API.Domain.Entities;
using OES.API.Persistence.Contexts;

namespace OES.API.Persistence.Repositories
{
    public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(OESAPIDbContext dbContext) : base(dbContext)
        {
        }
    }
}
