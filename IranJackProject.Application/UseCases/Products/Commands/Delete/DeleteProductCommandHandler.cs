using IranJackProject.Application.Services.Implementations.Products;
using IranJackProject.Application.Services.Interfaces.Products;
using IranJackProject.Application.Wrappers;
using MediatR;

namespace IranJackProject.Application.UseCases.Products.Commands.Delete;

public class DeleteProductCommandHandler(IProductService productService) : IRequestHandler<DeleteProductCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productService.GetByIdAsync(request.Id, cancellationToken);

        if (product is null)
            return Result<bool>.Failure("Product Not Found");

        await productService.DeleteAsync(product, cancellationToken);

        return Result<bool>.Success(true);
    }
}
