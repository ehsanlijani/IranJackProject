using IranJackProject.Infrastructure.Persistence.Context;
using IranJackProject.Infrastructure.Persistence.Repositories.Contracts.InventoryRecords;
using IranJackProject.Infrastructure.Persistence.Repositories.Contracts.Products;
using IranJackProject.Infrastructure.Persistence.Repositories.Implementations.InventoryRecords;
using IranJackProject.Infrastructure.Persistence.Repositories.Implementations.Products;
using IranJackProject.Infrastructure.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IranJackProject.Infrastructure;

public static class InfrastructureConfigurations
{
    public static IServiceCollection RegisterInfrastructureConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        RegisterContext(services, configuration);

        RegisterRepositories(services);

        RegisterUnitOfWork(services);

        return services;
    }

    #region Register Context

    private static IServiceCollection RegisterContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IranJackDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("IranJackDbContext"));
        });

        return services;
    }

    #endregion Register Context

    #region Register Repositories

    private static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddScoped<IInventoryRecordRepository, InventoryRecordRepository>();

        return services;
    }

    #endregion Register Repositories

    #region Register Unit Of Work

    private static IServiceCollection RegisterUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

    #endregion Register Unit Of Work
}