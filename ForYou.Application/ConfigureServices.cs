using AspNetCore.ServiceRegistration.Dynamic;
using ForYou.Application.Features.Category.Queries.GetCategoryList;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ForYou.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddServicesOfType<IScopedService>();
            services.AddServicesWithAttributeOfType<ScopedServiceAttribute>();
            services.AddMediatR(option =>
            {
                option.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            });
            return services;
        }
    }
}
