using IranJackProject.Application.Wrappers;
using MediatR;

namespace IranJackProject.Application.UseCases.Products.Commands.Delete;

public sealed record DeleteProductCommand
(
  Guid Id
) : IRequest<Result<bool>>;
