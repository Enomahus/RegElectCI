using Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ServicesConfigurations
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureAllServices(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            //services.AddMediator();
            services.AddApplicationServices();
            //services.AddApplicationFeaturesServices();
            //services.AddResourcesServices();
            //services.AddInfrastructureServices(configuration);
            //services.AddInfrastructurePersistenceServices(configuration);
            //services.AddInfrastructureSQLServerServices(configuration);
            //services.AddInfrastructureFileServices(configuration);
            //services.AddInfrastructureEmailServices(configuration);
            //services.AddInfrastructureIdentityServices(configuration);
            //services.AddInfrastructureSireneServices(configuration);
            //services.AddInfrastructureCityServices(configuration);
            //services.AddToolsServices(configuration);

            return services;
        }
    }
}
