using OES.API.Application.Repositories;
using OES.API.Domain.Entities;
using OES.API.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Persistence.Repositories
{
    public class EtkinlikReadRepository : ReadRepository<Etkinlik>, IEtkinlikReadRepository
    {
        public EtkinlikReadRepository(OESAPIDbContext dbContext) : base(dbContext)
        {
        }
    }
}
