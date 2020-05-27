using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace _05_Configuration
{
    public class Worker : IHostedService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _config;

        public Worker(ILogger<Worker> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config.GetSection("MyApplication");
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("MySetting: {MySetting}", _config["MySetting"]);
            _logger.LogInformation("MySecret: {MySecret}", _config["MySecret"]);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
