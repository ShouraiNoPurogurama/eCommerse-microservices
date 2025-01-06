using BusinessLogicLayer.DTO;
using DataAccessLayer.Entities;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer.MapsterConfig;

public static class MapsterConfiguration
{
    public static void RegisterMapsterConfiguration(this IServiceCollection services)
    {
        TypeAdapterConfig<ProductAddRequest, Product>.NewConfig()
            .Ignore(p => p.ProductName!);

        TypeAdapterConfig<ProductUpdateRequest, Product>.NewConfig()
            .Map(dest => dest.Category, src => src.Category.ToString());

        TypeAdapterConfig<Product, ProductResponse>.NewConfig()
            .Map(dest => dest.Category, src => Enum.Parse<CategoryOptions>(src.Category!));
    }
}