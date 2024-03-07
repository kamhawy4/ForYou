using ForYou.Application;
using ForYou.Application.Common.Helpers;
using ForYou.Application.Middleware;
using ForYou.Application.Services.Interfaces;
using ForYou.Domain.Contracts;
using ForYou.Infrastructure;
using ForYou.Infrastructure.Repositories;
using ForYou.Infrastructure.Services.Web;
using ForYou.SharedServices.Interfaces;
using ForYou.SharedServices.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(o => o.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddApplicationServicesForInfrastructure(builder.Configuration);
builder.Services.AddApplicationServicesForApp();

builder.Services.AddSwaggerGen(config =>
{

    // Add the Bearer token security definition
    config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.
                       Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    }); 

    // Require the Bearer token for all requests
    config.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

string encKey = builder.Configuration["AppSettings:JwtSettings:JwtEncryptionKey"]!;
string issuer = builder.Configuration["AppSettings:JwtSettings:Issuer"]!;
string audience = builder.Configuration["AppSettings:JwtSettings:Audience"]!;

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(encKey))
    };
});

var app = builder.Build();

var loggerFactory = app.Services.GetService<ILoggerFactory>();
loggerFactory.AddFile(builder.Configuration["Logging:LogFilePath"].ToString());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<CustomExceptionHandlingMiddleware>();

app.MapControllers();



app.Run();
