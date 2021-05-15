using Microsoft.Extensions.DependencyInjection;
using Tiririt.App.Internal.Service;
using Tiririt.App.Service;
using Tiririt.Data;
using MediatR;

namespace Tiririt.App
{
    public static class AppServiceCollection
    {
        public static IServiceCollection AddAppServiceCollection(this IServiceCollection services)
        {
            return services
                .AddMediatR(typeof(AppServiceCollection).Assembly)
                .AddDataService()
                .AddScoped<IStockService, StockService>()
                .AddScoped<IWatchListService, WatchListService>()
                .AddScoped<IStockSectorService, StockSectorService>()
                .AddScoped<IStockQuoteService, StockQuoteService>();                              
        }
    }
}