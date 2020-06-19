using Microsoft.Extensions.DependencyInjection;
using Tiririt.App.Internal.Service;
using Tiririt.App.Service;
using Tiririt.Data;

namespace Tiririt.App
{
    public static class AppServiceCollection
    {
        public static IServiceCollection AddAppServiceCollection(this IServiceCollection services)
        {
            return services                
                .AddDataService()
                .AddScoped<IStockService, StockService>()
                .AddScoped<IWatchListService, WatchListService>()
                .AddScoped<IStockSectorService, StockSectorService>()
                .AddScoped<IStockQuoteService, StockQuoteService>()
                .AddScoped<ITiriritPostService, TiriritPostService>();
        }
    }
}