using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core.MapsterConfig;

public static class MapsterConfiguration
{
    public static void RegisterMapsterConfiguration(this IServiceCollection services)
    {
        TypeAdapterConfig<ApplicationUser, AuthenticationResponse>
            .NewConfig()
            .Map(dest => dest.Gender, src => src.Gender!.ToString())
            .Ignore(dest => dest.Success)
            .Ignore(dest => dest.Token!)
            .IgnoreNullValues(true);

        TypeAdapterConfig<RegisterRequest, ApplicationUser>
            .NewConfig()
            .Map(dest => dest.Gender, src => src.GenderOption.ToString());
    }
}