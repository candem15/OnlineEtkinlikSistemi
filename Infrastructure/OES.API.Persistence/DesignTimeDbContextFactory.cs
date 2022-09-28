using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OES.API.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OESAPIDbContext>
    {
        public OESAPIDbContext CreateDbContext(string[] args) //Bu bize cli ile persistent içerisinden migration oluşturabilmemizi sağlıyacak.
        {
            DbContextOptionsBuilder<OESAPIDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionStringDockerPg);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
