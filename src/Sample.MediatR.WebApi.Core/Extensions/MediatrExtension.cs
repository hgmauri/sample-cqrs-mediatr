using Microsoft.Extensions.DependencyInjection;
using Sample.MediatR.Application.Queries;

namespace Sample.MediatR.WebApi.Core.Extensions;

public static class MediatrExtension
{
    public static void AddMediatRApi(this IServiceCollection services)
    {
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblyContaining(typeof(ProductByIdQuery)));
    }
}
