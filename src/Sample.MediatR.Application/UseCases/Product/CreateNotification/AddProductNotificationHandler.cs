using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;

namespace Sample.MediatR.Application.UseCases.Product.CreateNotification;

public class AddProductNotificationHandler : INotificationHandler<CreateProductNotification>
{
    public Task Handle(CreateProductNotification notification, CancellationToken cancellationToken)
    {
        //validações

        //pode chamar outros handlers

        //insere registros na base

        return Task.Run(() => Log.Information($"Successful product event. Id: {notification.Id}"));
    }
}
