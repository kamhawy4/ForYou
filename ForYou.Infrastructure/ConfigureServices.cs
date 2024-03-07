using ForYou.Application.Common.Helpers;
using ForYou.Application.Services.Interfaces;
using ForYou.Domain.Contracts;
using ForYou.Infrastructure.Repositories;
using ForYou.Infrastructure.Services.Web;
using ForYou.Infrastructure;
using ForYou.SharedServices.Interfaces;
using ForYou.SharedServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace ForYou.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServicesForInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<PostDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("PostConnectionString")));
            services.AddScoped<IHandleAttachment, HandleAttachment>();
            services.AddScoped<IWebTokenService, WebTokenService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.Configure<AppSettings>(options => configuration.GetSection("AppSettings").Bind(options));

            return services;
        }
    }
}
