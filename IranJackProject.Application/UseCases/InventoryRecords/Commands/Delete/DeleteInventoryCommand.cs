using IranJackProject.Application.Wrappers;
using MediatR;

namespace IranJackProject.Application.UseCases.InventoryRecords.Commands.Delete;

public sealed record DeleteInventoryCommand
(
    Guid Id
) : IRequest<Result<bool>>;
