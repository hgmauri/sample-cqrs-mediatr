using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.MediatR.Application.UseCases.Product.Get;

namespace Sample.MediatR.WebApi.Controllers;

[Route("api/[controller]")]
public class QueriesController : Controller
{
    private readonly IMediator _mediator;

    public QueriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("product")]
    public async Task<IActionResult> GetProductByIdAsync([FromQuery] GetProductsQuery product)
    {
        var queryProduct = await _mediator.Send(product);

        return Json(queryProduct);
    }

    [HttpGet("exception")]
    public Task<IActionResult> GetExceptionAsync()
    {
        throw new Exception("Erro aqui!");
    }
}
