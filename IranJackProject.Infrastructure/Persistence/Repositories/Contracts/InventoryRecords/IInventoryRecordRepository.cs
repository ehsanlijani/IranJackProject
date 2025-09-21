using IranJackProject.Domain.Models.InventoryRecords;
using System.Linq.Expressions;

namespace IranJackProject.Infrastructure.Persistence.Repositories.Contracts.InventoryRecords;

public interface IInventoryRecordRepository
{
    IQueryable<InventoryRecord> GetAll();

    Task<InventoryRecord?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task AddAsync(InventoryRecord record, CancellationToken cancellationToken = default);

    void Update(InventoryRecord record);

    void Delete(InventoryRecord record);
}
