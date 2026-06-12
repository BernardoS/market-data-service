using MarketDataService.Application.Interfaces.Providers;
using MarketDataService.Application.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MarketDataService.Workers
{
    public class MarketDataSyncWorker : BackgroundService
    {
        private const int _syncIntervalInMinutes = 15;
   
        private readonly IServiceScopeFactory  _scopeFactory;
        public MarketDataSyncWorker(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            TimeSpan interval = TimeSpan.FromMinutes(_syncIntervalInMinutes);

            using PeriodicTimer timer = new PeriodicTimer(interval);

            while(!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
            {
                ExecuteSynchronization();
            }
        }

        private void ExecuteSynchronization()
        {
            try
            {
                var syncId = Guid.NewGuid();
            
                Console.WriteLine($"Sincronizando dados... \n {syncId}");

                using IServiceScope scope = _scopeFactory.CreateScope();
                
                var marketDataSyncService = scope.ServiceProvider.GetRequiredService<IMarketDataSyncService>();
                
                marketDataSyncService.SyncEnabledAssets();
                
                Console.WriteLine($"Sincronização finalizada: {syncId} \n");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Houve um erro na sincronização: \n {e.Message}");
            }
            
        }
        
    }
}
