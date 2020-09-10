using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace WebLab
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddRazorPages();
            //services.AddAuthentication()
            //    .AddScheme<BasicAuthenticationOptions, BasicAuthenticationHandler>("Basic", null);
            services.AddOcelot(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.Use((context, next) =>
            {
                var endpointFeature = context.Features[typeof(Microsoft.AspNetCore.Http.Features.IEndpointFeature)]
                                                       as Microsoft.AspNetCore.Http.Features.IEndpointFeature;

                Microsoft.AspNetCore.Http.Endpoint endpoint = endpointFeature?.Endpoint;

                //Note: endpoint will be null, if there was no
                //route match found for the request by the endpoint route resolver middleware
                if (endpoint != null)
                {
                    var routePattern = (endpoint as Microsoft.AspNetCore.Routing.RouteEndpoint)?.RoutePattern
                                                                                               ?.RawText;

                    Console.WriteLine("Name: " + endpoint.DisplayName);
                    Console.WriteLine($"Route Pattern: {routePattern}");
                    Console.WriteLine("Metadata Types: " + string.Join(", ", endpoint.Metadata));
                }
                return next();
            });
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("API GATEWAY");
                });
            });
            app.UseOcelot().Wait();

        }
    }
}
