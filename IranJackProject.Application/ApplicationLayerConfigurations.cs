using IranJackProject.Application.Services.Implementations.Products;
using IranJackProject.Application.Services.Interfaces.Products;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using IranJackProject.Application.Services.Implementations.InventoryRecords;
using IranJackProject.Application.Services.Interfaces.InventoryRecords;
using FluentValidation.AspNetCore;

namespace IranJackProject.Application;

public static class ApplicationLayerConfigurations
{
    public static IServiceCollection RegisterApplicationConfigurations(this IServiceCollection services,
        IConfiguration configuration)
    {
        RegisterServices(services);

        RegisterMediatR(services);

        RegisterMapster(services);

        RegisterFluentValidation(services);

        return services;
    }

    #region Register Services

    private static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();

        services.AddScoped<IInventoryRecordService, InventoryRecordService>();
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

    #region Register Mapster

    private static void RegisterMapster(this IServiceCollection services)
    {
        TypeAdapterConfig? config = TypeAdapterConfig.GlobalSettings;

        Assembly? assembly = typeof(ApplicationLayerConfigurations).Assembly;

        List<Type>? registerTypes = assembly
            .GetTypes()
            .Where(type => typeof(IRegister).IsAssignableFrom(type) &&
                           !type.IsAbstract &&
                           !type.IsInterface)
            .ToList();

        foreach (Type? type in registerTypes)
        {
            IRegister? instance = (IRegister)Activator.CreateInstance(type)!;
            instance.Register(config);
        }

        services.AddSingleton(config);
        services.AddScoped<IMapper, Mapper>();
    }

    #endregion Register Mapster

    #region Register FluentValidation

    private static void RegisterFluentValidation(this IServiceCollection services)
    {
        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

        services.AddFluentValidation(configuration =>
        {
            var validatorTypes = assemblies.SelectMany(a => a.GetExportedTypes())
                .Where(t => t.IsClass && !t.IsAbstract && !t.IsGenericType &&
                            t.GetInterfaces().Any(i => i.IsGenericType &&
                                                       i.GetGenericTypeDefinition() == typeof(IValidator<>)));

            foreach (var validatorType in validatorTypes)
            {
                configuration.RegisterValidatorsFromAssemblyContaining(validatorType);
            }
        });
    }
    #endregion Register FluentValidation
}