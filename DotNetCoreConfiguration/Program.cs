using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreConfiguration.ConfigurationSources;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DotNetCoreConfiguration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var x = Path.Combine(Directory.GetCurrentDirectory(), "web.config");
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureAppConfiguration( (hostBuilderContext,configurationBuilder) =>
                {
                    if (hostBuilderContext.HostingEnvironment.IsDevelopment()){
                        configurationBuilder.AddXmlFile(Path.Combine(Directory.GetCurrentDirectory(), "config.Development.xml"));
                    }
                    else {
                        configurationBuilder.AddXmlFile(Path.Combine(Directory.GetCurrentDirectory(), "config.xml"));
                    }
                    configurationBuilder.AddIniFile(Path.Combine(Directory.GetCurrentDirectory(), "config.ini"));
                    configurationBuilder.Add<CsvConfigurationSource>(s => s.Path = "config.csv");
                }
                );
    }
}
