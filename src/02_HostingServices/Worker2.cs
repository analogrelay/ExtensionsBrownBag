using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace _02_HostingServices
{
    public class Worker2 : BackgroundService
    {
        private readonly IHostApplicationLifetime _appLifetime;

        public Worker2(IHostApplicationLifetime appLifetime)
        {
            _appLifetime = appLifetime;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine("Press 'S' to stop.");

                // Not cancellable :(. But if it was, we could use stoppingToken to know when we're being stopped.
                // I'm sure there's a better way. It's not really the point though.
                while (Console.ReadKey(intercept: true).Key != ConsoleKey.S) { }

                Console.WriteLine("Worker2 is shutting down the app");
                _appLifetime.StopApplication();
            });
        }
    }
}
