using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.MediatR.Application.Commands;

namespace Sample.MediatR.WebApi.Controllers;

[Route("api/[controller]")]
public class CommandsController : Controller
{
    private readonly IMediator _mediator;

    public CommandsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("product")]
    public async Task<IActionResult> PostProductAsync([FromBody] ProductSaveCommand product)
    {
        var command = await _mediator.Send(product);

        return Json(command);
    }

    [HttpPost("client")]
    public async Task<IActionResult> PostClientAsync([FromBody] ClientSaveCommand client)
    {
        var command = await _mediator.Send(client);

        return Json(command);
    }
}
