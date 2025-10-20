using Infrastructures.Persistence.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructures.Persistence
{
    public static class ConfigureService
    {
        public static IServiceCollection AddInfrastructurePersistenceService(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.Configure<DataConfiguration>(configuration.GetSection("DataConfig"));
            //services.AddApolloCoreNetAuthorizationPersistence();

            return services;
        }
    }
}
