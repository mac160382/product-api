using BookStore.Configuration.Constants;
using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.ProductService.Extensions
{
    public static class ConfigureSwagger
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
    }
}
