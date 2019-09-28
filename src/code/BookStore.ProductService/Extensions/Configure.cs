
using BookStore.Configuration.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;

namespace BookStore.ProductService.Extensions
{
    public static class Configure
    {
        public static IApplicationBuilder SwaggerConfigure(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();
            app.UseSwaggerUI(sw =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    sw.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });

            return app;
        }

        public static IApplicationBuilder UseIf(this IApplicationBuilder app, bool condition, Func<IApplicationBuilder, IApplicationBuilder> action)
        {
            return condition ? action(app) : app;
        }
    }
}
