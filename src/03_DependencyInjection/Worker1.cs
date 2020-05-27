using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace _03_DependencyInjection
{
    public class Worker1 : IHostedService
    {
        private readonly INumberService _numberService;

        public Worker1(INumberService numberService)
        {
            _numberService = numberService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(Worker1)}: The number is: {_numberService.Number}.");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
