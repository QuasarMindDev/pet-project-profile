using Pet.Project.Profile.Api.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ApiServicesConfig(builder.Configuration);

var logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext().CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

WebApplicationService.WebApplicationConfiguration(builder.Build()).Run();