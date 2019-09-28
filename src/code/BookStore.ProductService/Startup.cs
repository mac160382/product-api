using BookStore.Configuration.Constants;
using BookStore.ProductService.Extensions;
using BookStore.ProductService.Models.Validators;
using BookStore.ProductService.SwaggerConfig;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
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
            services.AddApiVersioning(o => {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
                ////o.ApiVersionReader = new MediaTypeApiVersionReader();
                ////o.ApiVersionSelector = new CurrentImplementationApiVersionSelector(o);
            });

            services.SwaggerConfigure(apiVersion)
                    .AddMvcCore()
                    .AddJsonFormatters()
                    .AddJsonCamelCaseOptions()
                    .AddApiExplorer()
                    .AddFluentValidations();
        } 

        ////// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        ////public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        ////{
        ////    app.UseMvc()
        ////       .SwaggerConfigure(apiVersion)               
        ////       .UseIf(env.IsDevelopment(), appBuilder => appBuilder.UseDeveloperExceptionPage());            
        ////}

        /// <summary>
        /// Configures the application using the provided builder, hosting environment, and API version description provider.
        /// </summary>
        /// <param name="app">The current application builder.</param>
        /// <param name="env">The current hosting environment.</param>
        /// <param name="provider">The API version descriptor provider used to enumerate defined API versions.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.UseMvc()
               .SwaggerConfigure(provider)
               .UseIf(env.IsDevelopment(), appBuilder => appBuilder.UseDeveloperExceptionPage());
        }
    }
}
