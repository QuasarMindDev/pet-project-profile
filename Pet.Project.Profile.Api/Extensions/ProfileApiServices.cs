﻿using Pet.Project.Profile.Api.Services;
using Pet.Project.Profile.Api.Services.Interfaces;
using Pet.Project.Profile.Infrastructure.Extensions;

namespace Pet.Project.Profile.Api.Extensions
{
    public static class ProfileApiServices
    {
        public static IServiceCollection ApiServicesConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructureServices(configuration);
            services.AddProfileServices();
            services.ConfigureCors();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }

        private static IServiceCollection AddProfileServices(this IServiceCollection services)
        {
            services.AddScoped<IAccessService, AccessService>();
            services.AddScoped<IActiveChatsService, ActiveChatsService>();
            services.AddScoped<IConfigurationService, ConfigurationService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ILikeService, LikeService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IMatchService, MatchService>();
            services.AddScoped<IPhoneService, PhoneService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IPreferencesService, PreferencesService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IReportsService, ReportsService>();
            services.AddScoped<IUserProfileService, UserProfileService>();

            return services;
        }
    }
}