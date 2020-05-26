using Tiririt.Data;
using Microsoft.Extensions.DependencyInjection;
using Tiririt.App.Internal.Service;
using Tiririt.App.Service;

namespace Tiririt.App
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddAppServiceCollection(this IServiceCollection services)
        {
            return services                
                .AddDataService()
                .AddTransient<IStockService, StockService>()
                .AddTransient<IWatchListService, WatchListService>()
                .AddTransient<IStockSectorService, StockSectorService>()
                .AddTransient<IStockQuoteService, StockQuoteService>();
        }
    }
}