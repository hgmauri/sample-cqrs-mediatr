using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sample.MediatR.Application.Notifications.ProductSavedNotification;
using Serilog;

namespace Sample.MediatR.Application.Commands.ProductSaveCommand;

public class ProductSaveCommandHandler : AsyncRequestHandler<ProductSaveCommand>
{
    private readonly IMediator _mediator;

    public ProductSaveCommandHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    protected override Task Handle(ProductSaveCommand request, CancellationToken cancellationToken)
    {
        _mediator.Publish(new ProductSavedNotification { Id = request.Id }, cancellationToken);

        return Task.Run(() => Log.Information("ProductSaveCommandAsyncHandler.Handle(ProductSaveCommandAsync)"));
    }
}
