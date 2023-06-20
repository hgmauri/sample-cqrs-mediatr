using Microsoft.EntityFrameworkCore;
using Sample.MediatR.Application;
using Sample.MediatR.Persistence.Context;
using Sample.MediatR.WebApi.Core.Extensions;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.AddSerilog("API MediatR", builder.Configuration);

    builder.Services.AddApiConfiguration();
   
    builder.Services.AddDbContext<ClientContext>(opt => opt.UseInMemoryDatabase("ClientContext"));
    builder.Services.AddAutoMapper(typeof(MapperProfile));
    builder.Services.AddElasticsearch(builder.Configuration);
    builder.Services.AddMediatRApi();
    builder.Services.AddMassTransitExtension();

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
