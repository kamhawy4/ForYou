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
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.Configure<Jwt>(builder.Configuration.GetSection("jwt"));

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

app.UseAuthorization();

app.UseMiddleware<CustomExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
