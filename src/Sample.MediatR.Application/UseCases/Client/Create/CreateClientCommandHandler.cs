using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Consumers;
using MassTransit;
using MediatR;
using Sample.MediatR.Application.Consumers.SendEmail;
using Sample.MediatR.Persistence.Context;
using Serilog;

namespace Sample.MediatR.Application.UseCases.Client.Create;

public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IPublishEndpoint _bus;
    private readonly ClientContext _context;

    public CreateClientCommandHandler(IPublishEndpoint publish, ClientContext context, IMapper mapper)
    {
        _bus = publish;
        _context = context;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Persistence.Context.Client>(request);

        await _context.Clients.AddAsync(entity);
        await _context.SaveChangesAsync();
        Log.Information($"Cliente cadastrado com sucesso! Código {entity.Id}");

        await _bus.Publish(new SendEmailEvent { Email = request.Email }, cancellationToken);
        await _bus.Publish(new IndexClientProductEvent { Client = entity }, cancellationToken);

        return await Task.FromResult(request.Id);
    }
}
