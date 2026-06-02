using Microsoft.Extensions.Hosting;

namespace MarketDataService.Workers
{
    public class MarketDataSyncWorker : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            TimeSpan interval = TimeSpan.FromSeconds(1);

            using PeriodicTimer timer = new PeriodicTimer(interval);

            while(!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
            {
                ExecuteMarketSynchronization();
            }
        }

        private void ExecuteMarketSynchronization()
        {
            Console.WriteLine($"Sincronizando dados... \n{Guid.NewGuid()}");
        }
    }
}
