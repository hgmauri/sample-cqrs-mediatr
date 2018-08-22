using System.Threading;
using System.Threading.Tasks;
using Serilog;

namespace MediatR.Commands.ProductSaveCommandAsync
{
	public class ProductSaveCommandAsyncHandler : AsyncRequestHandler<ProductSaveCommandAsync>
	{
		protected override Task Handle(ProductSaveCommandAsync request, CancellationToken cancellationToken)
		{
			return Task.Run(() => Log.Information("ProductSaveCommandAsyncHandler.Handle(ProductSaveCommandAsync)"));
		}
	}
}
