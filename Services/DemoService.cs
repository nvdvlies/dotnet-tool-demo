using Demo.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Demo.Services
{
    public class DemoService : IDemoService
    {
        private readonly ILogger<DemoService> _logger;
        private readonly AppSettings _appSettings;

        public DemoService(
            ILogger<DemoService> logger,
            IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _appSettings = appSettings.Value;
        }

        public async Task ExecuteAsync()
        {
            _logger.LogInformation($"AppSetting2: {_appSettings.AppSetting2}");

            // do stuff

            await Task.CompletedTask;
        }
    }
}
