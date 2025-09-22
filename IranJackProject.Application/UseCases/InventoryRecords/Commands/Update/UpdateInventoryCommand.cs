using System.Text.Json.Serialization;
using IranJackProject.Application.Wrappers;
using MediatR;

namespace IranJackProject.Application.UseCases.InventoryRecords.Commands.Update;

public sealed record UpdateInventoryCommand
(
    [property:JsonIgnore]
    Guid Id,
    Guid ProductId,
    int Quantity,
    DateTime ProductionDate
) : IRequest<Result<bool>>;
