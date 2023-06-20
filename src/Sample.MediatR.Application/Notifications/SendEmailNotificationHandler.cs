using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;

namespace Sample.MediatR.Application.Notifications;

public class SendEmailNotificationHandler : INotificationHandler<SendEmailNotification>
{
    public Task Handle(SendEmailNotification notification, CancellationToken cancellationToken)
    {
        //validações

        //pode chamar outros handlers

        //insere registros na base

        return Task.Run(() => Log.Information($"Successful email event. To: {notification.Email}"));
    }
}

public class SendEmailNotification : INotification
{
    public string Email { get; set; }
}
