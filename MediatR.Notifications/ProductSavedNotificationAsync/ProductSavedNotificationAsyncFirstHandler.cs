using System.Threading;
using System.Threading.Tasks;
using Serilog;

namespace MediatR.Notifications.ProductSavedNotificationAsync
{
	public class ProductSavedNotificationAsyncFirstHandler : INotificationHandler<ProductSavedNotificationAsync>
	{
		public Task Handle(ProductSavedNotificationAsync notification, CancellationToken cancellationToken)
		{
			return Task.Run(() => Log.Information("ProductSavedNotificationAsyncFirstHandler.Handle(ProductSavedNotificationAsync)"));
		}
	}
}
