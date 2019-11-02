using Demo.Models;
using Demo.Services;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Demo
{
    [Command(
        Name = "dotnet demo",
        FullName = "dotnet-demo",
        Description = "A description about the tool in general"
    )]
    [HelpOption]
    public class App
    {
        [Required(ErrorMessage = "Argument 'arg1' is required")]
        [Argument(0, Description = "Description for argument 'arg1'")]
        public string Argument1 { get; }

        [Option("-o|--option1", Description = "Description for option 'opt1'")]
        public string Option1 { get; }

        public async Task<int> OnExecute(
            ILogger<App> logger,
            IOptions<AppSettings> appSettings,
            IDemoService demoService)
        {
            logger.LogInformation($"AppSetting1: {appSettings.Value.AppSetting1}");
            logger.LogInformation($"Argument1: {Argument1}");
            logger.LogInformation($"Option1: {Option1}");

            await demoService.ExecuteAsync();

            return Constants.OK;
        }
    }
}
