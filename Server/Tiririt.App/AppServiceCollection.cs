using Microsoft.Extensions.DependencyInjection;
using Tiririt.Data;
using MediatR;
using FluentValidation;
using Tiririt.App.PipelineBehaviours;
using Tiririt.App.PipelineBehaviors;

namespace Tiririt.App
{
    public static class AppServiceCollection
    {
        public static IServiceCollection AddAppServiceCollection(this IServiceCollection services)
        {
            return services
                .AddDataService()
                .AddMediatR(typeof(AppServiceCollection).Assembly)
                .AddValidatorsFromAssembly(typeof(AppServiceCollection).Assembly)
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
                                                   
        }
    }
}