using Serilog;

namespace MediatR.Queries.ProductByIdQuery
{
	public class ProductByIdQueryHandler : RequestHandler<ProductByIdQuery, ProductByIdQueryResult>
	{
		protected override ProductByIdQueryResult Handle(ProductByIdQuery request)
		{
			Log.Information("ProductByIdQueryHandler.Handle(ProductByIdQuery)");

			return new ProductByIdQueryResult { Id = request.Id, Description = $"Description {request.Id}" };
		}
	}
}
