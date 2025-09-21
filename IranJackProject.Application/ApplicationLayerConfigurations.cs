using IranJackProject.Application.Services.Implementations.Products;
using IranJackProject.Application.Services.Interfaces.Products;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IranJackProject.Application;

public static class ApplicationLayerConfigurations
{
    public static IServiceCollection RegisterApplicationConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        RegisterServices(services);

        RegisterMediatR(services);

        return services;
    }

    #region Register Services

    private static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
    }

    #endregion Register Services

    #region Register MediatR

    private static void RegisterMediatR(this IServiceCollection services)
    {
        Assembly assembly = typeof(ApplicationLayerConfigurations).Assembly;

        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssemblies(assembly));
    }

    #endregion Register MediatR
}
