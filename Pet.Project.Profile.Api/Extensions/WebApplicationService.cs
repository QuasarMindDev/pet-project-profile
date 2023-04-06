namespace Pet.Project.Profile.Api.Extensions
{
    public static class WebApplicationService
    {
        public static WebApplication WebApplicationConfiguration(WebApplication application)
        {
            if (application.Environment.IsDevelopment())
            {
                application.UseSwagger();
                application.UseSwaggerUI();
            }
            application.UseAuthentication();
            application.UseAuthorization();
            application.UseHttpsRedirection();
            application.MapControllers();
            return application;
        }
    }
}