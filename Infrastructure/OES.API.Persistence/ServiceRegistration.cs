using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OES.API.Application.Repositories;
using OES.API.Domain.Identity;
using OES.API.Persistence.Contexts;
using OES.API.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<OESAPIDbContext>(opt =>
            {
                opt.UseNpgsql(Configuration.ConnectionStringDockerPg);
            });

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<OESAPIDbContext>();

            services.AddScoped<IEtkinlikReadRepository, EtkinlikReadRepository>();
            services.AddScoped<IEtkinlikWriteRepository, EtkinlikWriteRepository>();

            services.AddScoped<IKategoriReadRepository, KategoriReadRepository>();
            services.AddScoped<IKategoriWriteRepository, KategoriWriteRepository>();

            services.AddScoped<ISehirReadRepository, SehirReadRepository>();
            services.AddScoped<ISehirWriteRepository, SehirWriteRepository>();

            services.AddScoped<IKontenjanReadRepository, KontenjanReadRepository>();
            services.AddScoped<IKontenjanWriteRepository, KontenjanWriteRepository>();
        }
    }
}
