using IranJackProject.Application.Dtos.Products;
using IranJackProject.Application.Wrappers;
using MediatR;

namespace IranJackProject.Application.UseCases.Products.Queries.GetAll;

public sealed record GetAllProductsQuery() : IRequest<Result<IReadOnlyList<ProductDto>>>;
