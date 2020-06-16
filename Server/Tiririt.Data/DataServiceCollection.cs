using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tiririt.Data.Entities;
using Tiririt.Data.Internal;
using Tiririt.Data.Internal.Service;
using Tiririt.Data.Service;

namespace Tiririt.Data
{
    public static class DataServiceCollection 
    {
        public static IServiceCollection AddDataService(this IServiceCollection services) 
        {
            // TODO move connection string to connectionStrings.json
            services
                 .AddDbContext<TiriritDbContext>(options =>
                 {
                     options.UseNpgsql("Host=localhost; Database=TiriritDb; Username=arnold;Password=1q2w3e4r");
                 })

                 .AddScoped<IStockRepository, StockRepository>()
                 .AddScoped<IWatchListRepository, WatchListRepository>()
                 .AddScoped<IStockSectorRepository, StockSectorRepository>()
                 .AddScoped<IStockQuoteRepository, StockQuoteRepository>()
                 .AddScoped<ITiriritPostRepository, TiriritPostRepository>()
                 .AddScoped<IHashTagRepository, HashTagRepository>();

            services.AddIdentity<TIRIRIT_USER, IdentityRole<int>>(config =>
            {
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequiredLength = 4;
                config.Password.RequireDigit = false;
                config.Password.RequireLowercase = false;
                config.Password.RequireUppercase = false;
                config.SignIn.RequireConfirmedEmail = false;
            })
                .AddEntityFrameworkStores<TiriritDbContext>()
                .AddDefaultTokenProviders();

            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            })
                .AddInMemoryIdentityResources(IdentityServerConfig.Ids)
                .AddInMemoryApiResources(IdentityServerConfig.Apis)
                .AddInMemoryClients(IdentityServerConfig.Clients)
                .AddAspNetIdentity<TIRIRIT_USER>();

            builder.AddDeveloperSigningCredential();

            return services;
        }
    }    
}