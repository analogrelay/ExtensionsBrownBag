using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace _03_DependencyInjection
{
    public class Worker2 : IHostedService
    {
        private readonly INumberService _numberService;

        public Worker2(INumberService numberService)
        {
            _numberService = numberService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(Worker2)}: The number is: {_numberService.Number}.");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
