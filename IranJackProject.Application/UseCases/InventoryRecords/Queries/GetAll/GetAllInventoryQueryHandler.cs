using IranJackProject.Application.Dtos.InventoryRecords;
using IranJackProject.Application.Services.Interfaces.InventoryRecords;
using IranJackProject.Application.Wrappers;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IranJackProject.Application.UseCases.InventoryRecords.Queries.GetAll;

public class GetAllInventoryQueryHandler(IInventoryRecordService inventoryRecordService, IMapper mapper) : IRequestHandler<GetAllInventoryQuery, Result<IReadOnlyList<InventoryRecordDto>>>
{
    public async Task<Result<IReadOnlyList<InventoryRecordDto>>> Handle(GetAllInventoryQuery request, CancellationToken cancellationToken)
    {
        var inventoryRecords = await inventoryRecordService.GetAll().ToListAsync(cancellationToken);

        var mappedInventoryRecords = mapper.Map<IReadOnlyList<InventoryRecordDto>>(inventoryRecords);

        return Result<IReadOnlyList<InventoryRecordDto>>.Success(mappedInventoryRecords);
    }
}
