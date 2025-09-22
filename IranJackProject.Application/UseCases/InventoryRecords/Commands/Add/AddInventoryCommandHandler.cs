using IranJackProject.Application.Services.Interfaces.InventoryRecords;
using IranJackProject.Application.Services.Interfaces.Products;
using IranJackProject.Application.Wrappers;
using IranJackProject.Domain.Models.InventoryRecords;
using MapsterMapper;
using MediatR;

namespace IranJackProject.Application.UseCases.InventoryRecords.Commands.Add;

public class AddInventoryCommandHandler(IInventoryRecordService inventoryRecordService, IProductService productService, IMapper mapper) : IRequestHandler<AddInventoryCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(AddInventoryCommand request, CancellationToken cancellationToken)
    {
        var isProductExist = await productService.GetByIdAsync(request.ProductId, cancellationToken);

        if (isProductExist is null)
            return Result<Guid>.Failure("Product Not Found.");

        var inventoryRecord = mapper.Map<InventoryRecord>(request);

        await inventoryRecordService.AddAsync(inventoryRecord, cancellationToken);

        return Result<Guid>.Success(inventoryRecord.Id);
    }
}
