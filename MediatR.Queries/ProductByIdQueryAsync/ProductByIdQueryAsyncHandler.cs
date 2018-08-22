using System.Threading;
using System.Threading.Tasks;
using Serilog;

namespace MediatR.Queries.ProductByIdQueryAsync
{
	public class ProductByIdQueryAsyncHandler : IRequestHandler<ProductByIdQueryAsync, ProductByIdQueryAsyncResult>
	{
		public Task<ProductByIdQueryAsyncResult> Handle(ProductByIdQueryAsync request, CancellationToken cancellationToken)
		{
			Log.Information("ProductByIdQueryAsyncHandler.Handle(ProductByIdQueryAsync)");

			return Task.FromResult(new ProductByIdQueryAsyncResult { Id = request.Id, Description = $"Description {request.Id}" });
		}
	}
}
