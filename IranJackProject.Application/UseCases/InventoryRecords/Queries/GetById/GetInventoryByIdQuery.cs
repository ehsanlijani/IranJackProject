using IranJackProject.Application.Dtos.InventoryRecords;
using IranJackProject.Application.Wrappers;
using MediatR;

namespace IranJackProject.Application.UseCases.InventoryRecords.Queries.GetById;

public sealed record GetInventoryByIdQuery
(
  Guid Id
) : IRequest<Result<InventoryRecordDto>>;
