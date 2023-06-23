using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.MediatR.Application.UseCases.Product.Create;
using Sample.MediatR.Application.UseCases.Product.Get;

namespace Sample.MediatR.WebApi.Controllers;

[Route("api/[controller]")]
public class ProductController : Controller
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> PostProductAsync([FromBody] CreateProductCommand createProduct)
    {
        createProduct.Id = Guid.NewGuid();
        var command = await _mediator.Send(createProduct);

        return Json(command);
    }

    [HttpGet]
    public async Task<IActionResult> GetProductsAsync()
    {
        var command = await _mediator.Send(new GetProductsQuery());

        return Json(command);
    }
}
