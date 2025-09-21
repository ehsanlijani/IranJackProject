using IranJackProject.Application.Dtos.Products;
using IranJackProject.Application.UseCases.Products.Commands.Add;
using IranJackProject.Application.UseCases.Products.Commands.Update;
using IranJackProject.Domain.Models.Products;
using Mapster;

namespace IranJackProject.Application.Profiles.Products;

public static class ProductProfiler
{
    public static void RegisterMappings(TypeAdapterConfig config)
    {
        config.NewConfig<Product, ProductDto>();

        config.NewConfig<AddProductCommand, Product>();

        config.NewConfig<UpdateProductCommand, Product>();
    }
}
