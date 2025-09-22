using IranJackProject.Application.Dtos.InventoryRecords;
using IranJackProject.Application.Services.Interfaces.InventoryRecords;
using IranJackProject.Application.Wrappers;
using MapsterMapper;
using MediatR;

namespace IranJackProject.Application.UseCases.InventoryRecords.Queries.GetById;

public class GetInventoryByIdQueryHandler(IInventoryRecordService inventoryRecordService, IMapper mapper) : IRequestHandler<GetInventoryByIdQuery, Result<InventoryRecordDto>>
{
    public async Task<Result<InventoryRecordDto>> Handle(GetInventoryByIdQuery request, CancellationToken cancellationToken)
    {
        var inventory = await inventoryRecordService.GetByIdAsync(request.Id, cancellationToken);

        if (inventory is null)
            return Result<InventoryRecordDto>.Failure("Inventory Not Found.");

        var inventoryRecordDto = mapper.Map<InventoryRecordDto>(inventory);

        return Result<InventoryRecordDto>.Success(inventoryRecordDto);
    }
}