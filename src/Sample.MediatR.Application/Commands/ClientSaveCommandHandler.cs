using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using MediatR;
using Sample.MediatR.Application.Consumers;
using Serilog;

namespace Sample.MediatR.Application.Commands;

public class ClientSaveCommandHandler : IRequestHandler<ClientSaveCommand, string>
{
    private readonly IPublishEndpoint _publish;

    public ClientSaveCommandHandler(IPublishEndpoint publish)
    {
        _publish = publish;
    }

    public async Task<string> Handle(ClientSaveCommand request, CancellationToken cancellationToken)
    {
        //validações

        //insert product in database
        Log.Information($"Client saved successfully. Id: {request.Id}");

        //envia notificação de forma assíncrona
        await _publish.Publish(new SendEmailEvent { Email = "teste@email.com" }, cancellationToken);

        return await Task.FromResult("Ok");
    }
}

public class ClientSaveCommand : IRequest<string>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Description { get; set; }
}
