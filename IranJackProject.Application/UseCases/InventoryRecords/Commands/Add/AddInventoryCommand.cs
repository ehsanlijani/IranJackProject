using IranJackProject.Application.Wrappers;
using MediatR;

namespace IranJackProject.Application.UseCases.InventoryRecords.Commands.Add;

public sealed record AddInventoryCommand
(
    Guid ProductId,
    int Quantity,
    DateTime ProductionDate
) : IRequest<Result<Guid>>;
