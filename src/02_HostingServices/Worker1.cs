using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace _02_HostingServices
{
    public class Worker1 : IHostedService, IDisposable
    {
        private readonly Timer _timer;
        private readonly IHostEnvironment _environment;

        public Worker1(IHostEnvironment environment)
        {
            _timer = new Timer(Tick, null, Timeout.Infinite, Timeout.Infinite);
            _environment = environment;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(Worker2)} is running!");
            Console.WriteLine($" * Environment: {_environment.EnvironmentName}");
            Console.WriteLine($" * Content Root: {_environment.ContentRootPath}");
            Console.WriteLine($" * App Name: {_environment.ApplicationName}");
            _timer.Change(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(Worker2)} is stopping!");
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
            return Task.CompletedTask;
        }

        private void Tick(object state)
        {
            Console.WriteLine($"{nameof(Worker2)} is ticking!");
        }

        public void Dispose()
        {
            Console.WriteLine($"{nameof(Worker2)} is disposing!");
            _timer?.Dispose();
        }
    }
}
