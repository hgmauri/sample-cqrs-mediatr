using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;

namespace Sample.MediatR.Application.Notifications;

public class AddProductNotificationHandler : INotificationHandler<AddProductNotification>
{
    public Task Handle(AddProductNotification notification, CancellationToken cancellationToken)
    {
        //validações

        //pode chamar outros handlers

        //insere registros na base

        return Task.Run(() => Log.Information($"Successful product event. Id: {notification.Id}"));
    }
}

public class AddProductNotification : INotification
{
    public Guid Id { get; set; }
}
