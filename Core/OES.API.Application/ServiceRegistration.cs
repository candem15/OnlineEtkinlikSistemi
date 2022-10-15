﻿using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OES.API.Application.Validators;
using OES.API.Domain.Entities;
using OES.API.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            services.AddScoped<IValidator<Category>, CategoryValidator>();
            services.AddScoped<IValidator<City>, CityValidator>();
            services.AddScoped<IValidator<AppUser>, AppUserValidator>();
            services.AddScoped<IValidator<AppCompany>, AppCompanyValidator>();
        }
    }
}
