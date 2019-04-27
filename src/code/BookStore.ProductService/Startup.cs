using BookStore.Configuration.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
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
            services.AddMvc();            
            ConfigureServicesSwagger(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            ConfigureSwagger(app);            
        }

        private void ConfigureServicesSwagger(IServiceCollection services)
        {
            var info = new Info
            {
                Title = ApiMetaData.DocumentationTitle,
                Version = apiVersion,
                Description = ApiMetaData.DocumentationDescription
            };

            services.AddSwaggerGen(sw =>
            {
                sw.SwaggerDoc(apiVersion, info);
            });
        }

        private void ConfigureSwagger(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(sw =>
            {
                sw.SwaggerEndpoint(string.Format(ApiMetaData.DocumentationEndPoint, apiVersion), ApiMetaData.DocumentationDescription);
                sw.SupportedSubmitMethods(Array.Empty<SubmitMethod>());
            });
        }
    }
}
