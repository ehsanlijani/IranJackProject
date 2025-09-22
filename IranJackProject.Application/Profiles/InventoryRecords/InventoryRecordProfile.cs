using IranJackProject.Application.Dtos.InventoryRecords;
using IranJackProject.Application.UseCases.InventoryRecords.Commands.Add;
using IranJackProject.Application.UseCases.Products.Commands.Update;
using IranJackProject.Domain.Models.InventoryRecords;
using Mapster;

namespace IranJackProject.Application.Profiles.InventoryRecords;

public class InventoryRecordProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<InventoryRecord, InventoryRecordDto>()
            .Map(dest => dest.ProductName, src => src.Product.Name);

        config.NewConfig<AddInventoryCommand, InventoryRecord>();

        config.NewConfig<UpdateProductCommand, InventoryRecord>();
    }
}