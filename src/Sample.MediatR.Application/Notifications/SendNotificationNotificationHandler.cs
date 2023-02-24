using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;

namespace Sample.MediatR.Application.Notifications;

public class SendNotificationNotificationHandler : INotificationHandler<SendEmailNotification>
{
    public Task Handle(SendEmailNotification notification, CancellationToken cancellationToken)
    {
        return Task.Run(() => Log.Information($"Successful email event. To: {notification.Email}"));
    }
}

public class SendEmailNotification : INotification
{
    public string Email { get; set; }
}
