using CleanArchitecture.WebUI.Models;
using Flow.ResourceManager.Application.Traders.Commands;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers
{
    public class TradersController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateTrader([FromBody] CreateTraderCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateTrader([FromBody] UpdateTraderCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> RemoveTrader([FromBody] RemoveTraderCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}