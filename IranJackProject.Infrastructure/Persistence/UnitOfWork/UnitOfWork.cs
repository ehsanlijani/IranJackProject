using IranJackProject.Domain.Models.InventoryRecords;
using IranJackProject.Domain.Models.Products;
using IranJackProject.Infrastructure.Persistence.Context;
using IranJackProject.Infrastructure.Persistence.Repositories.Contracts.InventoryRecords;
using IranJackProject.Infrastructure.Persistence.Repositories.Contracts.Products;
using Microsoft.EntityFrameworkCore;

namespace IranJackProject.Infrastructure.Persistence.UnitOfWork;

public class UnitOfWork(IranJackDbContext iranJackDbContext) : IUnitOfWork
{
    public IProductRepository Products { get; }

    public IInventoryRecordRepository InventoryRecords { get; }

    public async ValueTask DisposeAsync()
        => await iranJackDbContext.DisposeAsync();

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
         => await iranJackDbContext.SaveChangesAsync(cancellationToken);
}
