using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;

namespace Sample.MediatR.Application.Notifications.ProductSavedNotification;

public class ProductSavedNotificationFirstHandler : INotificationHandler<ProductSavedNotification>
{
    public Task Handle(ProductSavedNotification notification, CancellationToken cancellationToken)
    {
        return Task.Run(() => Log.Information("ProductSavedNotificationFirstHandler"));
    }
}
