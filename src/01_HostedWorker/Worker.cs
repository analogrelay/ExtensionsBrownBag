using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace _01_HostedWorker
{
    public class Worker : IHostedService, IDisposable
    {
        private readonly Timer _timer;

        public Worker()
        {
            _timer = new Timer(Tick, null, Timeout.Infinite, Timeout.Infinite);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Worker is running!");
            _timer.Change(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Worker is stopping!");
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
            return Task.CompletedTask;
        }

        private void Tick(object state)
        {
            Console.WriteLine("Worker is ticking!");
        }

        public void Dispose()
        {
            Console.WriteLine("Worker is disposing!");
            _timer?.Dispose();
        }
    }
}
