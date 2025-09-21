using IranJackProject.Application.Wrappers;
using IranJackProject.Domain.Enums;
using MediatR;
using System.Text.Json.Serialization;

namespace IranJackProject.Application.UseCases.Products.Commands.Update;

public sealed record UpdateProductCommand
 (
    [property:JsonIgnore]
    Guid Id,
    string Name,
    CategoryEnum Category,
    decimal Price,
    bool IsActive
 ) : IRequest<Result<bool>>;
