using IranJackProject.Application.Services.Interfaces.InventoryRecords;
using IranJackProject.Application.Wrappers;
using MediatR;

namespace IranJackProject.Application.UseCases.InventoryRecords.Commands.Delete;

public class DeleteInventoryCommandHandler(IInventoryRecordService inventoryRecordService) : IRequestHandler<DeleteInventoryCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteInventoryCommand request, CancellationToken cancellationToken)
    {
        var inventory = await inventoryRecordService.GetByIdAsync(request.Id, cancellationToken);

        if (inventory is null)
            return Result<bool>.Failure("Inventory Not Found");

        await inventoryRecordService.DeleteAsync(inventory, cancellationToken);

        return Result<bool>.Success(true);
    }
}
