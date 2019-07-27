using BookStore.Configuration.Constants;
using BookStore.ProductService.Extensions;
using BookStore.ProductService.Models.Validators;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.IO;
using System.Reflection;

namespace BookStore.ProductService
{
    public class Startup
    {
        private static Version runtimeVersion = Assembly.GetExecutingAssembly().GetName().Version;
        private static string apiVersion = String.Format(ApiMetaData.AssemblyVersionFormat, runtimeVersion.Major, runtimeVersion.Minor);

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.SwaggerConfigure(apiVersion)
                    .AddMvcCore()
                    .AddJsonFormatters()
                    .AddApiExplorer()
                    .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductValidator>());
        } 

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.SwaggerConfigure(apiVersion).UseMvc();            
        }
    }
}
