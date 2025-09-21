using IranJackProject.Application.Wrappers;
using IranJackProject.Domain.Enums;
using MediatR;

namespace IranJackProject.Application.UseCases.Products.Commands.Add;

public sealed record AddProductCommand
(
  string Name,
  CategoryEnum Category,
  decimal Price,
  bool IsActive
) : IRequest<Result<Guid>>;
