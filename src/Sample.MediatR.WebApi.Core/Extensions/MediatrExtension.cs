using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Sample.MediatR.Application.Queries.ProductByIdQuery;

namespace Sample.MediatR.WebApi.Core.Extensions;

public static class MediatrExtension
{
    public static void AddMediatRApi(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ProductByIdQuery));
    }
}
