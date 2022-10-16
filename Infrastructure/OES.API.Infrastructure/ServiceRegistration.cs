using Microsoft.Extensions.DependencyInjection;
using OES.API.Application.Abstractions.Token;
using OES.API.Infrastructure.Services.Token;

namespace OES.API.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(ITokenHandler<>), typeof(TokenHandler<>));
        }
    }
}
