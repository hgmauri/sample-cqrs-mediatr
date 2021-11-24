using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.MediatR.Application.Queries.ProductByIdQuery;

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
    public async Task<IActionResult> GetProductByIdAsync([FromQuery] int id)
    {
        var query = new ProductByIdQuery { Id = id };
        var queryProduct = await _mediator.Send(query);

        return Json(queryProduct);
    }
}
