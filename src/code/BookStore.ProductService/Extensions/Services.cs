using BookStore.Configuration.Constants;
using BookStore.ProductService.Models.Validators;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

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

        public static IMvcCoreBuilder AddJsonCamelCaseOptions(this IMvcCoreBuilder builder)
        {
            return builder.AddJsonOptions(options => {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                };
                options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });
        }

        public static IMvcCoreBuilder AddFluentValidations(this IMvcCoreBuilder builder)
        {
            return builder.AddFluentValidation(x =>
            {
                x.RegisterValidatorsFromAssemblyContaining<ProductValidator>();
            });
        }
    }
}
