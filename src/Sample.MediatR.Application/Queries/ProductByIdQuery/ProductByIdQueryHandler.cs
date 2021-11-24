using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;

namespace Sample.MediatR.Application.Queries.ProductByIdQuery;

public class ProductByIdQueryHandler : IRequestHandler<ProductByIdQuery, ProductByIdQueryResult>
{
    public async Task<ProductByIdQueryResult> Handle(ProductByIdQuery request, CancellationToken cancellationToken)
    {
        Log.Information("Query performed successfully");

        return await Task.FromResult(new ProductByIdQueryResult { Id = request.Id, Description = $"Description {request.Id}" });
    }
}
