using IranJackProject.Application.Dtos.Products;
using IranJackProject.Application.Services.Interfaces.Products;
using IranJackProject.Application.Wrappers;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IranJackProject.Application.UseCases.Products.Queries.GetAll;

public class GetAllProductsQueryHandler(IProductService productService, IMapper mapper) : IRequestHandler<GetAllProductsQuery, Result<IReadOnlyList<ProductDto>>>
{
    public async Task<Result<IReadOnlyList<ProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await productService.GetAll().ToListAsync(cancellationToken);

        var mappedProducts = mapper.Map<IReadOnlyList<ProductDto>>(products);

        return Result<IReadOnlyList<ProductDto>>.Success(mappedProducts);
    }
}
