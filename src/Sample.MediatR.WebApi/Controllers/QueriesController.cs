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

    [HttpGet("productbyidquery")]
    public async Task<IActionResult> GetProductByIdAsync()
    {
        var query = new ProductByIdQuery { Id = 1 };
        var queryProduct = await _mediator.Send(query);

        return Json(queryProduct);
    }
}
