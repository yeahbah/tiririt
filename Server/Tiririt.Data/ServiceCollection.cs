using Microsoft.Extensions.DependencyInjection;
using Tiririt.Data.Internal;

namespace Tiririt.Data
{
    public static class ServiceCollection 
    {
        public static IServiceCollection AddDataService(this IServiceCollection services) 
        {
            return services.AddDbContext<TiriritDbContext>(options => {});
        }
    }
}