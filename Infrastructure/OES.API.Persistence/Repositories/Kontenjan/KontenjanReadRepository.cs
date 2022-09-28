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
    public class KontenjanReadRepository : ReadRepository<Kontenjan>, IKontenjanReadRepository
    {
        public KontenjanReadRepository(OESAPIDbContext dbContext) : base(dbContext)
        {
        }
    }
}
