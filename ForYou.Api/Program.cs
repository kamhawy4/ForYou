using ForYou.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ForYou.SharedServices.Interfaces;
using ForYou.SharedServices.Services;
using ForYou.Application.Contracts;
using ForYou.Api.Controllers;
using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using ForYou.Application.Features.Category.Queries.GetCategoryList;
using ForYou.Application.Features.Category.Queries.GetCategoryDetail;
using ForYou.Application;

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
builder.Services.AddScoped<IGategoryRepository, GategoryRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
