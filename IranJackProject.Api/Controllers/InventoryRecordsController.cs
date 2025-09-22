using IranJackProject.Application.UseCases.InventoryRecords.Commands.Add;
using IranJackProject.Application.UseCases.InventoryRecords.Commands.Delete;
using IranJackProject.Application.UseCases.InventoryRecords.Commands.Update;
using IranJackProject.Application.UseCases.InventoryRecords.Queries.GetAll;
using IranJackProject.Application.UseCases.InventoryRecords.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IranJackProject.Api.Controllers;

public class InventoryRecordsController(ISender sender) : BaseController
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        => Ok(await sender.Send(new GetAllInventoryQuery(), cancellationToken));

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        var result = await sender.Send(new GetInventoryByIdQuery(id), cancellationToken);

        if (result.IsSuccess is false)
            return NotFound(result.Error);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create([FromBody] AddInventoryCommand addInventoryCommand, CancellationToken cancellationToken = default)
    {
        var result = await sender.Send(addInventoryCommand, cancellationToken);

        if (result.IsSuccess is false)
            return BadRequest(result.Error);


        return Created(Url.Link(nameof(GetById), new { guid = result.Value }), result);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateInventoryCommand updateInventoryCommand, CancellationToken cancellationToken = default)
    {
        updateInventoryCommand = updateInventoryCommand with { Id = id };

        var result = await sender.Send(updateInventoryCommand, cancellationToken);

        if (result.IsSuccess is false)
            return NotFound(result.Error);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        var result = await sender.Send(new DeleteInventoryCommand(id), cancellationToken);

        if (result.IsSuccess is false)
            return NotFound(result.Error);

        return NoContent();
    }
}