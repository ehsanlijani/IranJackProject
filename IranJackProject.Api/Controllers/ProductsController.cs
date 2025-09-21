using IranJackProject.Application.UseCases.Products.Commands.Add;
using IranJackProject.Application.UseCases.Products.Commands.Delete;
using IranJackProject.Application.UseCases.Products.Commands.Update;
using IranJackProject.Application.UseCases.Products.Queries.GetAll;
using IranJackProject.Application.UseCases.Products.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IranJackProject.Api.Controllers;

public class ProductsController(ISender sender) : BaseController
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        => Ok(await sender.Send(new GetAllProductsQuery(), cancellationToken));

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        var result = await sender.Send(new GetProductByIdQuery(id), cancellationToken);

        if (result.IsSuccess is false)
            return NotFound(result.Error);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create([FromBody] AddProductCommand addProductCommand, CancellationToken cancellationToken = default)
    {
        var result = await sender.Send(addProductCommand, cancellationToken);

        if (result.IsSuccess is false)
            return BadRequest(result.Error);

        return Created();
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateProductCommand updateProductCommand, CancellationToken cancellationToken = default)
    {
        updateProductCommand = updateProductCommand with { Id = id };

        var result = await sender.Send(updateProductCommand, cancellationToken);

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
        var result = await sender.Send(new DeleteProductCommand(id), cancellationToken);

        if (result.IsSuccess is false)
            return NotFound(result.Error);

        return NoContent();
    }
}
