using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OES.API.Domain.Entities;
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
    }
}
