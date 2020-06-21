using Microsoft.Extensions.DependencyInjection;
using Tiririt.Core.Identity;

namespace Tiririt.Core
{
    public static class CoreServiceCollection
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            return services
                .AddScoped<ICurrentPrincipal, CurrentPrincipal>();
        }
    }
}
