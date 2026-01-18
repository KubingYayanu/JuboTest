using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jubo.Application.IoC
{
    public static class ConfigureApplicationServices
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            SetupMediatR(services);

            return services;
        }
        
        private static void SetupMediatR(IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(ConfigureApplicationServices).Assembly));
        }
    }
}