using IranJackProject.Application.Services.Interfaces.InventoryRecords;
using IranJackProject.Application.Services.Interfaces.Products;
using IranJackProject.Application.Wrappers;
using MapsterMapper;
using MediatR;

namespace IranJackProject.Application.UseCases.InventoryRecords.Commands.Update;

public class UpdateInventoryCommandHandler(IInventoryRecordService inventoryRecordService, IProductService productService, IMapper mapper) : IRequestHandler<UpdateInventoryCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(UpdateInventoryCommand request, CancellationToken cancellationToken)
    {
        var inventory = await inventoryRecordService.GetByIdAsync(request.Id, cancellationToken);

        if (inventory is null)
            return Result<bool>.Failure("Inventory Not Found");

        var isProductExist = await productService.GetByIdAsync(request.ProductId, cancellationToken);

        if (isProductExist is null)
            return Result<bool>.Failure("Product Not Found");

        mapper.Map(request, inventory);

        await inventoryRecordService.UpdateAsync(inventory, cancellationToken);

        return Result<bool>.Success(true);
    }
}
