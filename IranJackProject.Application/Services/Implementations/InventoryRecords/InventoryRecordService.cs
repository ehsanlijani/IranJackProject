using IranJackProject.Application.Services.Interfaces.InventoryRecords;
using IranJackProject.Domain.Models.InventoryRecords;
using IranJackProject.Infrastructure.Persistence.UnitOfWork;

namespace IranJackProject.Application.Services.Implementations.InventoryRecords;

public class InventoryRecordService(IUnitOfWork unitOfWork) : IInventoryRecordService
{
    public IQueryable<InventoryRecord> GetAll()
        => unitOfWork.InventoryRecords.GetAll();

    public async Task<InventoryRecord?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await unitOfWork.InventoryRecords.GetByIdAsync(id, cancellationToken);

    public async Task AddAsync(InventoryRecord inventoryRecord, CancellationToken cancellationToken)
    {
        await unitOfWork.InventoryRecords.AddAsync(inventoryRecord, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(InventoryRecord inventoryRecord, CancellationToken cancellationToken)
    {
        unitOfWork.InventoryRecords.Update(inventoryRecord);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(InventoryRecord inventoryRecord, CancellationToken cancellationToken)
    {
        unitOfWork.InventoryRecords.Delete(inventoryRecord);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

