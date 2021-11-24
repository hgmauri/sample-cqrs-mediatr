using System;
using MediatR;

namespace Sample.MediatR.Application.Notifications.ProductSavedNotification;

public class ProductSavedNotification : INotification
{
    public Guid Id { get; set; }
}
