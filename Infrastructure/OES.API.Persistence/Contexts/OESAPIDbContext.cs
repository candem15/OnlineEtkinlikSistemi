using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OES.API.Domain.Entities;
using OES.API.Domain.Entities.Common;
using OES.API.Domain.Identity;

namespace OES.API.Persistence.Contexts
{
    public class OESAPIDbContext : IdentityDbContext<BaseUser, AppRole, string>
    {
        public OESAPIDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<BaseUser> BaseUsers { get; set; }
        public DbSet<AppCompany> CompanyUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Quota> Quotas { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Event>()
                .HasOne(p => p.Organizer)
                .WithMany(e => e.Organizations)
                .HasForeignKey(k => k.OrganizerId);

            base.OnModelCreating(builder);

            builder.Entity<AppRole>().HasData(new AppRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Admin", NormalizedName = "ADMIN".ToUpper() });
            builder.Entity<AppRole>().HasData(new AppRole { Id = "391c72c8-9403-4c93-a4a4-4c2febd00d74", Name = "Basit", NormalizedName = "BASIT".ToUpper() });

            var hasher = new PasswordHasher<BaseUser>();

            builder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Name = "Eray",
                    Surname = "Berberoğlu",
                    Email = "admin@admin.com",
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
                        data.Entity.UpdatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        data.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                    default:
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
