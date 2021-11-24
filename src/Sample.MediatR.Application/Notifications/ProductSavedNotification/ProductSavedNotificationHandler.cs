using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;

namespace Sample.MediatR.Application.Notifications.ProductSavedNotification;

public class ProductSavedNotificationHandler : INotificationHandler<ProductSavedNotification>
{
    public Task Handle(ProductSavedNotification notification, CancellationToken cancellationToken)
    {
        return Task.Run(() => Log.Information($"Successful product event. Id: {notification.Id}"));
    }
}
