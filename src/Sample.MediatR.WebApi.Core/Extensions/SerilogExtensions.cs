using Microsoft.Extensions.Configuration;
using Serilog;

namespace Sample.MediatR.WebApi.Core.Extensions;

public static class SerilogExtensions
{
    public static void AddSerilogApi(IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.WithProperty("ApplicationName", $"API MediatR - {Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}")
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}")
            .CreateLogger();
    }
}
