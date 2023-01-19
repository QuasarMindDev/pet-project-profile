using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pet.Project.Profile.Domain.Models;
using Pet.Project.Profile.Infrastructure.Database;
using Pet.Project.Profile.Infrastructure.Database.Services;

namespace Pet.Project.Profile.Infrastructure.Extensions
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabaseServices(configuration);
            return services;
        }

        private static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseSettings>(configuration.GetSection("Database"));
            services.AddSingleton<MongoContext>();
            services.AddScoped<IDatabaseService, DatabaseService>();
            return services;
        }
    }
}