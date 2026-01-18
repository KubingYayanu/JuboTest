using Jubo.Domain.Aggregates.PatientAggregate;
using Jubo.Domain.SeedWork;
using Jubo.Infrastructure.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Jubo.Infrastructure.IoC
{
    public static class ConfigureInfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            SetupDbContext(services, configuration);
            SetupRepositories(services);

            return services;
        }

        private static void SetupDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseSettings>(settings =>
            {
                configuration.GetSection(DatabaseSettings.MedicalDatabaseSettings).Bind(settings);
            });

            services.AddDbContext<MedicalContext>((sp, options) =>
            {
                options.UseNpgsql(GetConnectionString(sp.GetRequiredService<IOptions<DatabaseSettings>>().Value));
            });
        }

        private static string GetConnectionString(IDatabaseSettings settings)
        {
            return settings.ConnectionString
                .Replace("{0}", settings.DatabaseName)
                .Replace("{1}", settings.UserName)
                .Replace("{2}", settings.Password);
        }

        private static void SetupRepositories(IServiceCollection services)
        {
            services.AddScoped<IPatientRepo, PatientRepo>();
        }
    }
}