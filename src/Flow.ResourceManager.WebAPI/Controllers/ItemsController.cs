using Flow.ResourceManager.Application.Items.Commands;
using Flow.ResourceManager.Application.Items.Dtos;
using Flow.ResourceManager.Application.Items.Queries;
using Flow.ResourceManager.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Flow.ResourceManager.WebAPI.Controllers;

public class ItemsController : ApiControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status201Created)]
    public async Task<ActionResult> AddItem([FromBody] CreateItemCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpPut]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateItem([FromBody] UpdateItemCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete]
    [ProducesResponseType(typeof(ApiResponse<int>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> RemoveItem([FromBody] RemoveItemCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<ItemDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> GetAll()
    {
        return Ok(await Mediator.Send(new GetItemsQuery()));
    }
}