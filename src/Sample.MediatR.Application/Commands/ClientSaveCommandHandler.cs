using MassTransit;
using MediatR;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;
using Sample.MediatR.Application.Consumers;

namespace Sample.MediatR.Application.Commands;

public class ClientSaveCommandHandler : IRequestHandler<ClientSaveCommand, string>
{
    private readonly IMediator _mediator;
    private readonly IPublishEndpoint _publish;

    public ClientSaveCommandHandler(IMediator mediator, IPublishEndpoint publish)
    {
        _mediator = mediator;
        _publish = publish;
    }

    public async Task<string> Handle(ClientSaveCommand request, CancellationToken cancellationToken)
    {
        //insert product in database
        Log.Information($"Client saved successfully. Id: {request.Id}");

        await _publish.Publish(new SendEmailEvent { Email = "teste@email.com" }, cancellationToken);

        return await Task.FromResult("Ok");
    }
}

public class ClientSaveCommand : IRequest<string>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Description { get; set; }
}
