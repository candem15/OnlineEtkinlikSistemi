using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OES.API.Domain.Entities;
using OES.API.Domain.Entities.Common;
using OES.API.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Persistence.Contexts
{
    public class OESAPIDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public OESAPIDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Etkinlik> Etkinlikler { get; set; }
        public DbSet<Sehir> Sehirler { get; set; }
        public DbSet<Kontenjan> Kontenjanlar { get; set; }
        public DbSet<Bilet> Biletler { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppRole>().HasData(new AppRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Admin", NormalizedName = "ADMIN".ToUpper() });
            builder.Entity<AppRole>().HasData(new AppRole { Id = "391c72c8-9403-4c93-a4a4-4c2febd00d74", Name = "Basit", NormalizedName = "BASIT".ToUpper() });
            builder.Entity<AppRole>().HasData(new AppRole { Id = "9505059f-22c8-4940-9889-52d6d05b5790", Name = "Firma", NormalizedName = "FIRMA".ToUpper() });

            var hasher = new PasswordHasher<AppUser>();

            builder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Ad = "admin",
                    PasswordHash = hasher.HashPassword(null, "adminPassword")
                }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                }
            );

        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker : Entityler üzerinden yapılan değişiklerin ya da yeni eklenen verinin yakalanmasını sağlayan propertydir. Bu metotda SaveChangesAsync override edilerek entitynin ilgili propertylerine atama gerçekleştirilerek bir Interceptor(kesme-araya girme) inşa edildi.

            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                switch (data.State)
                {
                    case EntityState.Modified:
                        data.Entity.GuncellenmeTarihi = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        data.Entity.OlusturulmaTarihi = DateTime.UtcNow;
                        break;
                    default:
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
