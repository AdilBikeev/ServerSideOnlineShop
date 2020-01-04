using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using HttpServer.Common.Loggers;
using Microsoft.Extensions.Configuration;

namespace ServerSideOnlineShop
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvcCore(options => options.EnableEndpointRouting = false)
                .AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
 
            app.UseStaticFiles();
            app.UseMvc();           // νες ξοπεδελεννϋυ μΰπψπσςξβ

            var configBuilder = new ConfigurationBuilder()
                    .SetBasePath(env?.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            configBuilder.AddEnvironmentVariables();
            Configuration = configBuilder.Build();
            Logger.Path = Configuration["Logging:Path"];
        }
    }
}
