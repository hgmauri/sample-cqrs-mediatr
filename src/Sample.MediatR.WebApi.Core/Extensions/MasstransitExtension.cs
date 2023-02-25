using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Sample.MediatR.Application.Consumers;

namespace Sample.MediatR.WebApi.Core.Extensions;
public static class MasstransitExtension
{
    public static void AddMassTransitExtension(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.AddDelayedMessageScheduler();
            x.SetKebabCaseEndpointNameFormatter();

            x.AddConsumer<SendEmailConsumerHandler>(typeof(SendEmailConsumerHandlerDefinition));

            x.UsingInMemory((ctx, cfg) =>
            {
                cfg.UseDelayedMessageScheduler();
                cfg.ConfigureEndpoints(ctx, new KebabCaseEndpointNameFormatter("dev", false));
                cfg.UseMessageRetry(retry => { retry.Interval(3, TimeSpan.FromSeconds(5)); });
            });
        });
    }
}
