
using BookStore.Configuration.Constants;
using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;

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

        public static IApplicationBuilder UseIf(this IApplicationBuilder app, bool condition, Func<IApplicationBuilder, IApplicationBuilder> action)
        {
            return condition ? action(app) : app;
        }
    }
}
