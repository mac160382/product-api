using BookStore.Configuration.Constants;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.ProductService.Extensions
{
    public static class Services
    {
        public static IServiceCollection SwaggerConfigure(this IServiceCollection services, string apiVersion)
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

                // Set the comments path for the Swagger JSON and UI.
                var basePath = AppContext.BaseDirectory;
                var files = Directory.GetFiles(basePath, "*.xml");
                foreach (var file in files)
                {
                    sw.IncludeXmlComments(file);
                }
            });

            return services;
        }
    }
}
