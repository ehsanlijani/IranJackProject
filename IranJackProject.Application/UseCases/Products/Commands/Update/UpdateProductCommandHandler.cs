using IranJackProject.Application.Services.Interfaces.Products;
using IranJackProject.Application.Wrappers;
using IranJackProject.Domain.Models.Products;
using MapsterMapper;
using MediatR;

namespace IranJackProject.Application.UseCases.Products.Commands.Update;

public class UpdateProductCommandHandler(IProductService productService, IMapper mapper) : IRequestHandler<UpdateProductCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productService.GetByIdAsync(request.Id, cancellationToken);

        if (product is null)
            return Result<bool>.Failure("Product Not Found");

        mapper.Map(request, product);

        await productService.UpdateAsync(product, cancellationToken);

        return Result<bool>.Success(true);
    }
}
