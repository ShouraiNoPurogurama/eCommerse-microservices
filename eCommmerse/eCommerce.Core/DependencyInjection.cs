using System.Reflection;
using eCommerce.Core.MapsterConfig;
using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using eCommerce.Core.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add core services to the dependency injection container
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UsersService>();
        services.RegisterMapsterConfiguration();
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        return services;
    }
}