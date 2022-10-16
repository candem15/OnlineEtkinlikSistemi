using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OES.API.Application.Features.Commands.AppCompany.RegisterCompany;
using OES.API.Application.Features.Commands.AppUser.CreateUser;
using OES.API.Application.Features.Commands.Category.CreateCategory;
using OES.API.Application.Features.Commands.Category.UpdateCategory;
using OES.API.Application.Features.Commands.City.CreateCity;
using OES.API.Application.Features.Commands.City.UpdateCity;
using OES.API.Application.Features.Commands.Event.CreateEvent;
using OES.API.Application.Features.Commands.Event.UpdateEvent;
using OES.API.Application.Validators;

namespace OES.API.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceRegistration));
            services.AddAutoMapper(typeof(ServiceRegistration));
            services.AddHttpClient();

            //Validators

            services.AddScoped<IValidator<CreateCategoryCommandRequest>, CreateCategoryValidator>();
            services.AddScoped<IValidator<UpdateCategoryCommandRequest>, UpdateCategoryValidator>();
            services.AddScoped<IValidator<CreateCityCommandRequest>, CreateCityValidator>();
            services.AddScoped<IValidator<UpdateCityCommandRequest>, UpdateCityValidator>();
            services.AddScoped<IValidator<CreateUserCommandRequest>, CreateUserValidator>();
            services.AddScoped<IValidator<RegisterCompanyCommandRequest>, RegisterCompanyValidator>();
            services.AddScoped<IValidator<CreateEventCommandRequest>, CreateEventValidator>();
            services.AddScoped<IValidator<UpdateEventCommandRequest>, UpdateEventValidator>();
        }
    }
}
