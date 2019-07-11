using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BookStore.ProductService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
             WebHost.CreateDefaultBuilder(args)
                 .UseContentRoot(Directory.GetCurrentDirectory())
                 .ConfigureAppConfiguration(SetUpConfiguration)
                 .UseStartup<Startup>()
                 .Build();

        private static void SetUpConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
        {
            ////Removing default configuration options
            builder.Sources.Clear();
            builder.AddJsonFile("appsettings.json", false, true);
            builder.AddJsonFile($"appsettings.{ctx.HostingEnvironment.EnvironmentName}.json", false, true);
            builder.SetBasePath(ctx.HostingEnvironment.ContentRootPath);
            /*this is unic point to read secret */
            //builder.AddUserSecrets<Startup>();
            ////.AddXmlFile("", true)
            ////.AddEnvironmentVariables();
        }
    }
}
