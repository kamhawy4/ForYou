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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddMediatR(o => o.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddApplicationServices();
builder.Services.AddDbContext<PostDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PostConnectionString")));

builder.Services.AddScoped<IHandleAttachment, HandleAttachment>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

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
