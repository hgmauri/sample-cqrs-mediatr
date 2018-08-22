using System.Threading;
using System.Threading.Tasks;
using Serilog;

namespace MediatR.Notifications.ProductSavedNotificationAsync
{
	public class ProductSavedNotificationAsyncSecondHandler : INotificationHandler<ProductSavedNotificationAsync>
	{
		public Task Handle(ProductSavedNotificationAsync notification, CancellationToken cancellationToken)
		{
			return Task.Run(() => Log.Information("ProductSavedNotificationAsyncSecondHandler.Handle(ProductSavedNotificationAsync)"));
		}
	}
}
