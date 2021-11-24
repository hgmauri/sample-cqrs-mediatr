using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;

namespace Sample.MediatR.Application.Notifications.SendEmailNotification;

public class SendNotificationNotificationHandler : INotificationHandler<SendEmailNotification>
{
    public Task Handle(SendEmailNotification notification, CancellationToken cancellationToken)
    {
        return Task.Run(() => Log.Information($"Successful email event. To: {notification.Email}"));
    }
}
