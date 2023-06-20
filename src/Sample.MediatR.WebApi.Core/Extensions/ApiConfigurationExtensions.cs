using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sample.MediatR.WebApi.Core.Middlewares;

namespace Sample.MediatR.WebApi.Core.Extensions;
public static class ApiConfigurationExtensions
{
    public static void AddApiConfiguration(this IServiceCollection services)
    {
        services.AddRouting(options => options.LowercaseUrls = true);

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddControllers();
    }

    public static void UseApiConfiguration(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();
        app.MapControllers();

        app.UseMiddleware<ErrorHandlingMiddleware>();
    }
}
