using IranJackProject.Application.Dtos.Products;
using IranJackProject.Application.Services.Interfaces.Products;
using IranJackProject.Application.Wrappers;
using MapsterMapper;
using MediatR;

namespace IranJackProject.Application.UseCases.Products.Queries.GetById;

public class GetProductByIdQueryHandler(IProductService productService, IMapper mapper) : IRequestHandler<GetProductByIdQuery, Result<ProductDto>>
{
    public async Task<Result<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await productService.GetByIdAsync(request.Id, cancellationToken);

        if (product is null)
            return Result<ProductDto>.Failure("Product Not Found.");

        var productDto = mapper.Map<ProductDto>(product);

        return Result<ProductDto>.Success(productDto);
    }
}
