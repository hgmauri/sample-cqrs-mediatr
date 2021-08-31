using MediatR.Queries.ProductByIdQuery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

            services.AddResponseCompression();
            services.AddResponseCaching();

            services.AddMvc()
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver())
                .SetCompatibilityVersion(CompatibilityVersion.Latest);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseRouting();

            app.UseResponseCompression();

            app.UseResponseCaching();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        }

        private static IMediator BuildMediator(IServiceCollection services)
        {
            services.AddScoped<ServiceFactory>(p => p.GetService);

            services.AddMediatR(typeof(ProductByIdQueryHandler));

            var provider = services.BuildServiceProvider();

            return provider.GetRequiredService<IMediator>();
        }
    }
}
