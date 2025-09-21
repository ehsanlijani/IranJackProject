using IranJackProject.Application.Dtos.Products;
using IranJackProject.Application.Services.Interfaces.Products;
using IranJackProject.Application.Wrappers;
using MapsterMapper;
using MediatR;

namespace IranJackProject.Application.UseCases.Products.Queries.GetAll;

public class GetAllProductsQueryHandler(IProductService productService, IMapper mapper) : IRequestHandler<GetAllProductsQuery, Result<IReadOnlyList<ProductDto>>>
{
    public async Task<Result<IReadOnlyList<ProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = productService.GetAll().ToList();

        var mappedProducts = mapper.Map<IReadOnlyList<ProductDto>>(products);

        return Result<IReadOnlyList<ProductDto>>.Success(mappedProducts);
    }
}
