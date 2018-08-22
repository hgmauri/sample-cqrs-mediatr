using Serilog;

namespace MediatR.Notifications.ProductSavedNotification
{
	public class ProductSavedNotificationSecondHandler : NotificationHandler<ProductSavedNotification>
	{
		protected override void Handle(ProductSavedNotification notification)
		{
            Log.Information("ProductSavedNotificationSecondHandler.Handle(ProductSavedNotification)");
		}
	}
}
