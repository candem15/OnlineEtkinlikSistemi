using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OES.API.Persistence.Contexts;

namespace OES.API.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OESAPIDbContext>
    {
        public OESAPIDbContext CreateDbContext(string[] args) //Cli ile persistent içerisinden migration oluşturabilmek için.
        {
            DbContextOptionsBuilder<OESAPIDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionStringDockerPg);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
