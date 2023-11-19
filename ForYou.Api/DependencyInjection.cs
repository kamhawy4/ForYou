using ForYou.Application.Features.Category.Queries.GetCategoryList;
using MediatR;
using System.Reflection;

namespace ForYou.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            return services;

        }
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetAssembly(typeof(GetCategoryListQuery)));
        }
    }
}
