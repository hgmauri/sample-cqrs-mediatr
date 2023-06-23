using MediatR;

namespace Sample.MediatR.Application.UseCases.Email.Send;
public class SendEmailNotification : INotification
{
    public string Email { get; set; }
}
