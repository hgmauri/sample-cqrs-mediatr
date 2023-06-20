using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.MediatR.Application.Commands;
using Sample.MediatR.Application.Queries;

namespace Sample.MediatR.WebApi.Controllers;

[Route("api/[controller]")]
public class ClientController : Controller
{
    private readonly IMediator _mediator;

    public ClientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> PostClientAsync([FromBody] AddClientCommand client)
    {
        client.Id = Guid.NewGuid();
        var command = await _mediator.Send(client);

        return Json(command);
    }

    [HttpGet]
    public async Task<IActionResult> GetClientAsync()
    {
        var command = await _mediator.Send(new GetClientsQuery());

        return Json(command);
    }
}
