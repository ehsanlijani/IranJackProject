using IranJackProject.Application.Dtos.InventoryRecords;
using IranJackProject.Application.Wrappers;
using MediatR;

namespace IranJackProject.Application.UseCases.InventoryRecords.Queries.GetAll;

public sealed record GetAllInventoryQuery() : IRequest<Result<IReadOnlyList<InventoryRecordDto>>>;
