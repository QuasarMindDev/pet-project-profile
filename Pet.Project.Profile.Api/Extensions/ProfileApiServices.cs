using Pet.Project.Profile.Infrastructure.Extensions;

namespace Pet.Project.Profile.Api.Extensions
{
    public static class ProfileApiServices
    {
        public static IServiceCollection ApiServicesConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddInfrastructureServices(configuration);
            return services;
        }
    }
}