using Tiririt.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Tiririt.App
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddAppServiceCollection(this IServiceCollection services)
        {
            return services
                .AddDataService();
        }
    }
}