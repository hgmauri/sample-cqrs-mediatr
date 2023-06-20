using Elastic.Apm.NetCoreAll;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nest;
using Sample.MediatR.Persistence.Elasticsearch;

namespace Sample.MediatR.WebApi.Core.Extensions;
public static class ElasticsearchExtensions
{
    public static void AddElasticsearch(this IServiceCollection services, IConfiguration configuration)
    {
        var defaultIndex = configuration["ElasticsearchSettings:defaultIndex"];
        var basicAuthUser = configuration["ElasticsearchSettings:username"];
        var basicAuthPassword = configuration["ElasticsearchSettings:password"];

        var settings = new ConnectionSettings(new Uri(configuration["ElasticsearchSettings:uri"]));

        if (!string.IsNullOrEmpty(defaultIndex))
            settings = settings.DefaultIndex(defaultIndex);

        if (!string.IsNullOrEmpty(basicAuthUser) && !string.IsNullOrEmpty(basicAuthPassword))
            settings = settings.BasicAuthentication(basicAuthUser, basicAuthPassword);

        settings.EnableApiVersioningHeader();

        var client = new ElasticClient(settings);

        services.AddSingleton<IElasticClient>(client);
        services.TryAddScoped(typeof(IBaseElasticRepository<>), typeof(ElasticRepository<>));
    }

    public static void UseElasticApm(this IApplicationBuilder app, IConfiguration configuration)
    {
        //https://www.elastic.co/guide/en/apm/agent/dotnet/current/configuration-on-asp-net-core.html
        app.UseAllElasticApm(configuration);
    }
}
