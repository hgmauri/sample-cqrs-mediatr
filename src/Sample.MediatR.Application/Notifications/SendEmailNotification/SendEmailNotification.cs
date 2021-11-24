using MediatR;

namespace Sample.MediatR.Application.Notifications.SendEmailNotification;

public class SendEmailNotification : INotification
{
    public string Email { get; set; }
}
