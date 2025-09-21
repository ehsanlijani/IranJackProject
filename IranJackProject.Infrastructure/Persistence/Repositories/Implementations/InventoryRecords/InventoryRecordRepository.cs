using IranJackProject.Domain.Models.InventoryRecords;
using IranJackProject.Domain.Models.Products;
using IranJackProject.Infrastructure.Persistence.Context;
using IranJackProject.Infrastructure.Persistence.Repositories.Contracts.InventoryRecords;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IranJackProject.Infrastructure.Persistence.Repositories.Implementations.InventoryRecords;

public class InventoryRecordRepository(IranJackDbContext iranJackDbContext) : IInventoryRecordRepository
{
    public IQueryable<InventoryRecord> GetAll()
        => iranJackDbContext.InventoryRecords.AsNoTracking().AsQueryable();

    public async Task<InventoryRecord?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await iranJackDbContext.InventoryRecords.SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);

    public async Task AddAsync(InventoryRecord record, CancellationToken cancellationToken = default)
        => await iranJackDbContext.InventoryRecords.AddAsync(record, cancellationToken);

    public void Update(InventoryRecord record)
        => iranJackDbContext.InventoryRecords.Update(record);

    public void Delete(InventoryRecord record)
        => iranJackDbContext.InventoryRecords.Remove(record);
}
