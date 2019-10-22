using MediatR.Commands.ProductSaveCommand;
using MediatR.Commands.ProductSaveCommandAsync;
using MediatR.Notifications.ProductSavedNotification;
using MediatR.Notifications.ProductSavedNotificationAsync;
using MediatR.Queries.ProductByIdQuery;
using MediatR.Queries.ProductByIdQueryAsync;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace MediatR.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            BuildMediator(services);

            services.AddRouting();
            services.AddCors();

            services.AddMvc()
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver())
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.EnvironmentName == "Development")
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=queries}/{action=productbyidquery}");
                endpoints.MapRazorPages();
            });
        }

        private static IMediator BuildMediator(IServiceCollection services)
        {
            services.AddScoped<ServiceFactory>(p => p.GetService);

            services.Scan(scan => scan
                .FromAssembliesOf(typeof(IMediator),
                    typeof(ProductByIdQueryHandler),
                    typeof(ProductByIdQueryAsyncHandler),
                    typeof(ProductSaveCommandHandler),
                    typeof(ProductSaveCommandAsyncHandler),
                    typeof(ProductSavedNotificationFirstHandler),
                    typeof(ProductSavedNotificationAsyncFirstHandler))
                .AddClasses()
                .AsImplementedInterfaces());

            var provider = services.BuildServiceProvider();

            return provider.GetRequiredService<IMediator>();
        }
    }
}
