using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;

namespace Sample.MediatR.Application.Queries.ProductByIdQuery;

public class ProductByIdQueryHandler : IRequestHandler<ProductByIdQuery, ProductByIdQueryResult>
{
    public Task<ProductByIdQueryResult> Handle(ProductByIdQuery request, CancellationToken cancellationToken)
    {
        Log.Information("ProductByIdQueryAsyncHandler.Handle(ProductByIdQueryAsync)");

        return Task.FromResult(new ProductByIdQueryResult { Id = request.Id, Description = $"Description {request.Id}" });
    }
}
