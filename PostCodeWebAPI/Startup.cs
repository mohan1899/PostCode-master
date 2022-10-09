using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PostCodeWebAPI.Service;

namespace PostCodeWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPostCodeService, PostCodeService>();
            services.AddSingleton(typeof(ILogger), typeof(Logger<Startup>));
            services.AddSwaggerGen();
            services.AddControllers();
            services.AddCors(options => {
                options.AddDefaultPolicy(
                    builder => {
                        builder.WithOrigins(Configuration["CorsSettings:Origin"]).AllowAnyOrigin().SetIsOriginAllowed((host) => true).AllowAnyMethod().AllowAnyHeader();
                    });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger().UseSwaggerUI(setup =>
            {
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(setup.RoutePrefix) ? "." : "..";
                setup.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "Version 1.0");
                setup.OAuthAppName("Lambda Api");
                setup.OAuthScopeSeparator(" ");
                setup.OAuthUsePkce();
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Welcome to PostCode Application");
                });
            });
        }
    }
}
