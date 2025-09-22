using IranJackProject.Domain.Models.InventoryRecords;
using IranJackProject.Domain.Models.Products;
using IranJackProject.Infrastructure.Persistence.Context;
using IranJackProject.Infrastructure.Persistence.Repositories.Contracts.InventoryRecords;
using IranJackProject.Infrastructure.Persistence.Repositories.Contracts.Products;
using Microsoft.EntityFrameworkCore;

namespace IranJackProject.Infrastructure.Persistence.UnitOfWork;

public class UnitOfWork(
    IranJackDbContext iranJackDbContext,
    IProductRepository products,
    IInventoryRecordRepository inventoryRecords
    ) : IUnitOfWork
{
    public IProductRepository Products { get; } = products;

    public IInventoryRecordRepository InventoryRecords { get; } = inventoryRecords;

    public async ValueTask DisposeAsync()
        => await iranJackDbContext.DisposeAsync();

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
         => await iranJackDbContext.SaveChangesAsync(cancellationToken);
}
