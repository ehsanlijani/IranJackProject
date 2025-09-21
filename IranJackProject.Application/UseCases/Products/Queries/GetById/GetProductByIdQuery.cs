using IranJackProject.Application.Dtos.Products;
using IranJackProject.Application.Wrappers;
using MediatR;

namespace IranJackProject.Application.UseCases.Products.Queries.GetById;

public sealed record GetProductByIdQuery
(
  Guid Id
) : IRequest<Result<ProductDto>>;
