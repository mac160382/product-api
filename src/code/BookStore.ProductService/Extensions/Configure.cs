using BookStore.Configuration.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.ProductService.Extensions
{
    public static class Configure
    {
        public static IApplicationBuilder SwaggerConfigure(this IApplicationBuilder app, string apiVersion)
        {
            app.UseSwagger();
            app.UseSwaggerUI(sw =>
            {
                sw.SwaggerEndpoint(string.Format(ApiMetaData.DocumentationEndPoint, apiVersion), ApiMetaData.DocumentationDescription);
                sw.SupportedSubmitMethods(Array.Empty<SubmitMethod>());
                sw.RoutePrefix = string.Empty;
            });

            return app;
        }

        public static IMvcCoreBuilder AddJsonCamelFormatters(this IMvcCoreBuilder builder)
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
    }
}
