using System.Threading.Tasks;
using MediatR.Commands.ProductSaveCommandAsync;
using Microsoft.AspNetCore.Mvc;

namespace MediatR.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CommandsController : Controller
    {
        private readonly IMediator _mediator;

        public CommandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("product")]
        public async Task<IActionResult> PostProduct([FromBody] ProductSaveCommandAsync product)
        {
            var plastico = await _mediator.Send(product);

            return Json(plastico);
        }
    }
}
