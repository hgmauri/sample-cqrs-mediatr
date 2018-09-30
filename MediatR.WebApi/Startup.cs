using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using MediatR.Commands.ProductSaveCommand;
using MediatR.Commands.ProductSaveCommandAsync;
using MediatR.Notifications.ProductSavedNotification;
using MediatR.Notifications.ProductSavedNotificationAsync;
using MediatR.Pipeline;
using MediatR.Queries.ProductByIdQuery;
using MediatR.Queries.ProductByIdQueryAsync;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}",
                    defaults: new { controller = "queries", action = "productbyidquery" }
                );
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
