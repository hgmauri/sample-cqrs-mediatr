using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR.Queries.ProductByIdQuery;
using MediatR.Queries.ProductByIdQueryAsync;
using Microsoft.AspNetCore.Mvc;

namespace MediatR.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class QueriesController : Controller
    {
        private readonly IMediator _mediator;

        public QueriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("productbyidquery")]
        public async Task<IActionResult> ProductByIdQuery()
        {
            var query = new ProductByIdQuery { Id = 1 };
            var plastico = await _mediator.Send(query);

            return Json(plastico);
        }

        [HttpGet("productbyidqueryasync")]
        public async Task<IActionResult> ProductByIdQueryAsync()
        {
            var query = new ProductByIdQueryAsync { Id = 1 };
            var plastico = await _mediator.Send(query);

            return Json(plastico);
        }

    }
}
