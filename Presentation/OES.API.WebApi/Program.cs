using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using OES.API.Application;
using OES.API.Infrastructure;
using OES.API.Persistence;
using System.Reflection;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddControllers()
    .AddXmlSerializerFormatters()
    .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
    .AddFluentValidation(opt =>
    {
        opt.RegisterValidatorsFromAssemblyContaining(typeof(Program));
    });

builder.Services.AddCors(opt => opt.AddDefaultPolicy(policy =>
    policy.WithOrigins("https://localhost:4200", "http://localhost:4200").AllowAnyHeader().AllowAnyMethod()
));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// JWT konfigürasyonlarý
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Default", options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateAudience = true, // Oluþturulacak token deðerini hangi site/origin in kullanacaðýný belirliyoruz.
            ValidateIssuer = true, // Oluþturulacak token ýn daðýtýmýný kimin yapýcaðýný belirliyoruz.
            ValidateIssuerSigningKey = true, // Oluþturulacak olan token ýn kendi uygulumamýza ait olduðunu belirten unique key.
            ValidateLifetime = true, // Token ýn geçerlilik süresini belirler.

            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
            LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false,
            RoleClaimType = ClaimsIdentity.DefaultRoleClaimType
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
