using ForYou.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ForYou.SharedServices.Interfaces;
using ForYou.SharedServices.Services;
using System.Reflection;
using ForYou.Application;
using ForYou.Application.Interfaces;
using ForYou.Domain.Contracts;
using ForYou.Infrastructure.Repositories;
using ForYou.Application.Middleware;
using ForYou.SharedServices.Helper;
using Microsoft.Extensions.Configuration;
using ForYou.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using ForYou.Application.Services.Interfaces;
using ForYou.Infrastructure.Services.Web;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(o => o.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddApplicationServices();
builder.Services.AddDbContext<PostDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PostConnectionString")));
builder.Services.AddIdentity<UserEntity, IdentityRole>().AddEntityFrameworkStores<PostDbContext>();
builder.Services.AddScoped<IHandleAttachment, HandleAttachment>();
builder.Services.AddScoped<IWebTokenService, WebTokenService>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


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


builder.Services.Configure<Jwt>(builder.Configuration.GetSection("jwt"));

string encKey = builder.Configuration["jwt:key"]!;
string issuer = builder.Configuration["jwt:Issuer"]!;
string audience = builder.Configuration["jwt:Audience"]!;

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
