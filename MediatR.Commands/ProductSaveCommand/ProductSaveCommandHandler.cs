using Serilog;

namespace MediatR.Commands.ProductSaveCommand
{
	public class ProductSaveCommandHandler : RequestHandler<ProductSaveCommand>
	{
		protected override void Handle(ProductSaveCommand request)
		{
            Log.Information("ProductSaveCommandHandler.Handle(ProductSaveCommand)");
		}
	}
}
