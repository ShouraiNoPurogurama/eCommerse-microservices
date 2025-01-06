using BusinessLogicLayer.MapsterConfig;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer;

public static class DependencyInjection
{
    public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
    {
        services.RegisterMapsterConfiguration();
        
        return services;
    }
}