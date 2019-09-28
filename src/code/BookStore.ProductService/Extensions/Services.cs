using BookStore.Configuration.Constants;
using BookStore.ProductService.Models.Validators;
using BookStore.ProductService.SwaggerConfig;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;

namespace BookStore.ProductService.Extensions
{
    public static class Services
    {
        public static IServiceCollection SwaggerConfigure(this IServiceCollection services)
        {
            services.AddVersionedApiExplorer(
                options =>
                {
                    // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                    // note: the specified format code will format the version as "'v'major[.minor][-status]"
                    options.GroupNameFormat = "'v'VVV";

                    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                    // can also be used to control the format of the API version in route templates
                    options.SubstituteApiVersionInUrl = true;
                });

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddSwaggerGen(sw =>
            {
                // add a custom operation filter which sets default values
                sw.OperationFilter<SwaggerDefaultValues>();

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

        public static IServiceCollection ApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(o => {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
                ////o.ApiVersionReader = new MediaTypeApiVersionReader();
                ////o.ApiVersionSelector = new CurrentImplementationApiVersionSelector(o);
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
