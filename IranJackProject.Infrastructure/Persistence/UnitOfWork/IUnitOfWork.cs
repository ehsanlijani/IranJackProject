using IranJackProject.Infrastructure.Persistence.Repositories.Contracts.InventoryRecords;
using IranJackProject.Infrastructure.Persistence.Repositories.Contracts.Products;

namespace IranJackProject.Infrastructure.Persistence.UnitOfWork;

public interface IUnitOfWork : IAsyncDisposable
{
    public IProductRepository Products { get; }

    public IInventoryRecordRepository InventoryRecords { get; }

    Task SaveChangesAsync(CancellationToken cancellationToken);
}
