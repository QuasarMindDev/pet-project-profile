using Pet.Project.Profile.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ApiServicesConfig(builder.Configuration);
WebApplicationService.WebApplicationConfiguration(builder.Build()).Run();