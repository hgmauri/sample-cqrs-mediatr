using MediatR;

namespace Sample.MediatR.Application.Notifications.ProductSavedNotification;

public class ProductSavedNotification : INotification
{
    public long Id { get; set; }
}
