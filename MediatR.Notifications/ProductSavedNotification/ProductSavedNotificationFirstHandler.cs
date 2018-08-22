using Serilog;

namespace MediatR.Notifications.ProductSavedNotification
{
	public class ProductSavedNotificationFirstHandler : NotificationHandler<ProductSavedNotification>
	{
		protected override void Handle(ProductSavedNotification notification)
		{
		    Log.Information("ProductSavedNotificationFirstHandler.Handle(ProductSavedNotification)");
		}
	}
}
