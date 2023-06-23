using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.MediatR.Application.UseCases.Client.Create;
using Sample.MediatR.Application.UseCases.Client.Get;

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
    public async Task<IActionResult> PostClientAsync([FromBody] CreateClientCommand client)
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
