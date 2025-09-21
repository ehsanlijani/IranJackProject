using IranJackProject.Application.Services.Interfaces.Products;
using IranJackProject.Application.Wrappers;
using IranJackProject.Domain.Models.Products;
using MapsterMapper;
using MediatR;

namespace IranJackProject.Application.UseCases.Products.Commands.Add;

public class AddProductCommandHandler(IProductService productService, IMapper mapper) : IRequestHandler<AddProductCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var product = mapper.Map<Product>(request);

        await productService.AddAsync(product, cancellationToken);

        return Result<Guid>.Success(product.Id);
    }
}
