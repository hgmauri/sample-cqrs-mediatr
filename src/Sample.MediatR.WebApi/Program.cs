using Microsoft.EntityFrameworkCore;
using Sample.MediatR.Application;
using Sample.MediatR.Application.UseCases.Product.Get;
using Sample.MediatR.Persistence.Context;
using Sample.MediatR.WebApi.Core.Extensions;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.AddSerilog("API MediatR", builder.Configuration);

    builder.Services.AddApiConfiguration();
   
    builder.Services.AddDbContext<ClientContext>(opt => opt.UseInMemoryDatabase("ClientContext"));
    builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblyContaining(typeof(GetProductsQuery)));
    builder.Services.AddAutoMapper(typeof(MapperProfile));
    builder.Services.AddElasticsearch(builder.Configuration);

    builder.Services.AddMassTransitExtension(builder.Configuration);

    var app = builder.Build();
    app.UseApiConfiguration();
    app.UseElasticApm(builder.Configuration);

    await app.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.Information("Server Shutting down...");
    Log.CloseAndFlush();
}
