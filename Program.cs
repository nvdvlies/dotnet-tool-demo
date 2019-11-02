using Demo.Models;
using Demo.Services;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        public static async Task<int> Main(string[] args)
        {
            return await new HostBuilder()
                .ConfigureLogging((context, builder) =>
                {
                    builder.AddConsole();
                })
                .ConfigureServices((context, services) => {
                    var configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", false)
                        .AddJsonFile("appsettings.user.json", true)
                        .Build();

                    services.AddOptions<AppSettings>().Bind(configuration);

                    services.AddSingleton<IDemoService, DemoService>();
                    services.AddSingleton(PhysicalConsole.Singleton);
                })
                .RunCommandLineApplicationAsync<App>(args);
        }
    }
}
