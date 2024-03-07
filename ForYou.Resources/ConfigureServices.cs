using ForYou.SharedServices.Services;

namespace ForYou.Resources
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddResourceService(this IServiceCollection services)
        {
            services.AddSingleton<IResourceHandler, ResourceHandler>();

            return services;
        }
    }
}
