using IranJackProject.Domain.Models.InventoryRecords;
using IranJackProject.Domain.Models.Products;

namespace IranJackProject.Application.Services.Interfaces.InventoryRecords;

public interface IInventoryRecordService
{
    IQueryable<InventoryRecord> GetAll();

    Task<InventoryRecord?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task AddAsync(InventoryRecord inventoryRecord, CancellationToken cancellationToken);

    Task UpdateAsync(InventoryRecord inventoryRecord, CancellationToken cancellationToken);

    Task DeleteAsync(InventoryRecord inventoryRecord, CancellationToken cancellationToken);
}