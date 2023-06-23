using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Sample.MediatR.Application.Consumers.IndexClientProducts;
using Sample.MediatR.Application.Consumers.SendEmail;

namespace Sample.MediatR.WebApi.Core.Extensions;
public static class MasstransitExtension
{
    public static void AddMassTransitExtension(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(x =>
        {
            x.AddDelayedMessageScheduler();
            x.SetKebabCaseEndpointNameFormatter();

            x.AddConsumer<SendEmailConsumerHandler>(typeof(SendEmailConsumerHandlerDefinition));
            x.AddConsumer<IndexClientProductConsumerHandler>(typeof(IndexClientProductConsumerDefinition));

            x.UsingAzureServiceBus((ctx, cfg) =>
            {
                cfg.UseDelayedMessageScheduler();
                cfg.Host(configuration.GetConnectionString("AzureServiceBus"), pol => pol.RetryLimit = 3);
                cfg.ConfigureEndpoints(ctx, new KebabCaseEndpointNameFormatter("dev", false));
                cfg.UseMessageRetry(retry => { retry.Interval(3, TimeSpan.FromSeconds(5)); });
            });
        });
    }
}
