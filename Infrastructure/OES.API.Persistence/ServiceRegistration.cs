using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OES.API.Application.Abstractions.Services;
using OES.API.Application.Repositories;
using OES.API.Domain.Identity;
using OES.API.Persistence.Contexts;
using OES.API.Persistence.Repositories;
using OES.API.Persistence.Services;
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
                opt.UseLazyLoadingProxies();
            });

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true; //Unique email adresi ile kayıt sağlar
            }).AddEntityFrameworkStores<OESAPIDbContext>()
            .AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider); //Şifre değişikliği için gerekli provider bilgisi eklendi.

            services.AddIdentityCore<AppCompany>().AddEntityFrameworkStores<OESAPIDbContext>()
            //.AddTokenProvider<DataProtectorTokenProvider<AppCompany>>(TokenOptions.DefaultProvider)
            .AddSignInManager<SignInManager<AppCompany>>(); 

            services.AddScoped<IEventReadRepository, EventReadRepository>();
            services.AddScoped<IEventWriteRepository, EventWriteRepository>();

            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

            services.AddScoped<ICityReadRepository, CityReadRepository>();
            services.AddScoped<ICityWriteRepository, CityWriteRepository>();

            services.AddScoped<IQuotaReadRepository, QuotaReadRepository>();
            services.AddScoped<IQuotaWriteRepository, QuotaWriteRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IEventService, EventService>();
        }
    }
}
